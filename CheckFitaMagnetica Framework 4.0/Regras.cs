using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace CheckFitaMagnetica
{
	/// <summary>
	/// Classe que contém todas as regras de negócio.
	/// </summary>
	public class Regras
	{
		/// <summary>
		/// Construtor vazio.
		/// </summary>
		public Regras()
		{			}

		/// <summary>
		/// Objetos inicializdos.
		/// </summary>
		public static string ciimagFinal = "";
		public static string pathFinal = "";
		public static string cdsheetFinal = "";
		String flagDeAchado1;
		String flagDeAchado2;
		String flagDeAchado3;
		private static IDbTransaction transacao;
		DataSet ds;
		public static IDbConnection conexao;
		public IDbCommand comando;
		public IDbDataAdapter adaptador;
		public static string stringDataFimFinal = "";
		public static string stringDataIniFinal = "";

		/// <summary>
		/// Metodo que recebe o RG de outros lugares e o torna uma variável pública.
		/// </summary>
		/// <param name="RG">Número do RG</param>
		public static void ExportarParaConsultar(String cdsheet, String ciimag, String path)
		{
			ciimagFinal = ciimag.ToString();
			pathFinal = path.ToString();
			cdsheetFinal = cdsheet.ToString();
		}

		/// <summary>
		/// Metodo que recebe as datas iniciais e finais 
		/// de outros lugares e as torna públicas.
		/// </summary>
		/// <param name="stringDataIni">Data inicial</param>
		/// <param name="stringDataFim">Data final</param>
		public static void ExportarParaVisualizar(String stringDataIni, String stringDataFim)
		{
			stringDataIniFinal = stringDataIni.ToString();
			stringDataFimFinal = stringDataFim.ToString();
		}

		/// <summary>
		/// Verifica se existe o cd_sheet
		/// </summary>
		/// <returns>tru or false se tiver algo no dtb ou se for null</returns>
		public bool metodoPesquisarCdsheet()
		{
			return AtualizaDS();
		}

		/// <summary>
		/// Iniciar Transacao do SQL.
		/// </summary>
		/// <param name="tipoBase">"SQL SERVER", "ACCESS"</param>
		/// <param name="banco">"ASCENT","PROJETO","TCI_SCAN","ACCESS", "RG"</param>
		/// <param name="projeto">"IIRGD","DETRAN","CRIMINAL"</param>
		public void IniciarTransacao(String tipoBase, 
			String projeto, 
			String banco)
		{
			try 
			{
				if(transacao == null)
				{
					if(tipoBase.Trim().ToUpper() == "SQL SERVER")
					{
						transacao = Conexao(projeto,banco).BeginTransaction();
						if(transacao == null)
							throw new Exception("CONEXÃO NAO INICIADA!");
					}
				}
			}
			catch(InvalidOperationException exp)
			{
				if(conexao != null)
					conexao.Close();
				conexao = null;
				throw new Exception("INVALID OPERATION AO INICIAR TRANSACAO: " + exp.Message);
			}
			catch(Exception exp)
			{
				throw new Exception("ERRO AO INICIAR TRANSACAO: " + exp.Message);
			}
		}	

		/// <summary>
		/// Método que atualiza os DataSet´s.
		/// </summary>
		/// <returns>Retorna o DataTable gerado.</returns>
		public bool AtualizaDS()
		{
			DataTable dtb = null;

			try 
			{
				return this.fn_preparadores_cadastrados();

				if(ds.Tables[0].Rows.Count > 0 )
				{
					ds.Tables[0].TableName = "Retatório";

					dtb = new DataTable();

					// Coloca-se os nomes das colunas em branco porque
					//mais a diante irá se recuperar os nomes originais da base.

					dtb.Columns.Add("", typeof(string));
					dtb.Columns.Add("", typeof(string));
					dtb.Columns.Add("", typeof(string));
                
					DataRow Linha;

					for (int x=0; x < ds.Tables[0].Rows.Count; x++)
					{
						Linha = dtb.NewRow();
						for (int y=0; y < ds.Tables[0].Columns.Count; y++)
						{
							Linha[y] = ds.Tables[0].Rows[x][y].ToString();

							//Descobre o nome original da coluna no DataSet e poe no DataTable.
							dtb.Columns[y].ColumnName = ds.Tables[0].Columns[y].ColumnName.ToString();
						}
						dtb.Rows.Add(Linha);
					}
				}
				else
				{
					dtb = null;
				}
			}
			catch(Exception ex) 
			{
				throw new Exception(ex.Message);
			}
			//return dtb;
		}

		/// <summary>
		/// Submete a transacao do SQL.
		/// </summary>
		public void SubmeterTransacao()
		{	
			if(transacao != null)
			{
				transacao.Commit();
				transacao.Dispose();
				conexao.Close();
			}
			transacao = null;
			conexao = null;
			
		}

		/// <summary>
		/// Desfaz uma transacao do SQL.
		/// </summary>
		public void DesfazerTransacao()
		{
			if(transacao != null)
			{
				transacao.Rollback();
				transacao.Dispose();
				transacao = null;
				conexao.Close();
			}
			transacao = null;
			conexao = null;
		}

		/// <summary>
		/// Conexao do Banco SQL Server.
		/// </summary>
		/// <param name="banco">"PROJETO","ASCENT","TCI_SCAN","ACCESS","RG"</param>
		/// <param name="projeto">"IIRGD","DETRAN","CRIMINAL"</param>
		public static SqlConnection Conexao(String projeto, 
			String banco)
		{
			try 
			{
				if(conexao == null)
				{				
					if(conexao != null) 
					{
						if(conexao.State == ConnectionState.Open)
							conexao.Close();
					}
					conexao  = new SqlConnection(fn_formar_string_conexao(projeto,banco));
					conexao.Open();				
				}
			}
			catch(Exception exception)
			{
				if(conexao != null) 
				{
					conexao.Close();
					conexao = null;
				}
				throw new Exception("ERRO AO CONECTAR COM A BASE: " + exception.Message);
			}
			return (SqlConnection) conexao;
		}

		/// <summary>
		/// Retorna todos os preparadores cadastrados em formato DataSet.
		/// </summary>
		/// <returns>DataSet</returns>
		public bool fn_preparadores_cadastrados()
		{
			DataSet ds_retorno = null;
			IDataReader reader = null;
			try
			{
				ds_retorno = new DataSet();
				IDbCommand comando = null;
				String str_sql = "";

				str_sql = Querys.Query1(cdsheetFinal, ciimagFinal, pathFinal);

				comando = this.Comando;
				comando.CommandText = str_sql;
				comando.CommandType = CommandType.Text;
				comando.Transaction = Transacao;
				reader = comando.ExecuteReader();

				if(reader.Read())
					return true;
				else
					return false;
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				if(reader != null)
					reader.Close();
			}
			//return ds_retorno;
		}

		/// <summary>
		/// Retorna todos os preparadores cadastrados em formato DataSet.
		/// </summary>
		/// <param name="numeroTabela"></param>
		/// <param name="lote"></param>
		/// <param name="caixa"></param>
		/// <returns>DataSet</returns>
		public DataSet fn_preparadores_cadastrados(int numeroTabela, String lote, String caixa)
		{
			DataSet ds_retorno = null;
			try
			{
				ds_retorno = new DataSet();
				IDbCommand comando = null;
				IDbDataAdapter adaptador = null;
				String str_sql = "";

				if(numeroTabela == 1)
				{
					str_sql = Querys.Query1(cdsheetFinal, ciimagFinal, pathFinal);
				}

				comando = this.Comando;
				comando.CommandText = str_sql;
				comando.CommandType = CommandType.Text;
				comando.Transaction = Transacao;
				adaptador = this.Adaptador;
				adaptador.Fill(ds_retorno);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return ds_retorno;
		}


		/// <summary>
		/// Retorna String de conexão de uma base.
		/// </summary>
		/// <param name="banco">"ASCENT","PROJETO","TCI_SCAN","ACCESS","RG"</param>
		/// <param name="projeto">"IIRGD","DETRAN","CRIMINAL"</param>
		/// <returns>String</returns>
		public static String fn_formar_string_conexao(String projeto, 
			String banco) 
		{
			String str_sql_bd_connection = "";
			try 
			{
				string SERVER_BD = getValor("CONEXAO_BD/" + projeto + "/" + banco + "/DATA_SOURCE");
				string DATABASE_BD = getValor("CONEXAO_BD/" + projeto + "/" + banco + "/INITIAL_CATALOG");
				string PWD_BD = getValor("CONEXAO_BD/"  + projeto + "/" + banco + "/PWD");
				string USER_BD =  getValor("CONEXAO_BD/"  + projeto + "/" + banco + "/UID");
				string CONN_TIMEOUT_BD = getValor("CONEXAO_BD/CONN_TIMEOUT");

				str_sql_bd_connection += "Data Source=" + SERVER_BD;
				str_sql_bd_connection += ";Initial Catalog=" + DATABASE_BD;
				str_sql_bd_connection += ";User ID=" + USER_BD;
				str_sql_bd_connection += ";Password=" + PWD_BD;
				str_sql_bd_connection += ";Connection Timeout=" + CONN_TIMEOUT_BD;
			
			}
			catch(Exception exp) 
			{
				throw new Exception(exp.ToString());
			}
			
			return str_sql_bd_connection;
		}

		/// <summary>
		/// Faz SQLComand usando a conexão.
		/// </summary>
		public SqlCommand Comando
		{
			get
			{
				this.comando = new SqlCommand();
				this.comando.CommandTimeout = conexao.ConnectionTimeout;
				this.comando.Connection = conexao;
				return (SqlCommand)this.comando;
			}
			set
			{
				this.comando = value;
			}
		}

		/// <summary>
		/// Transacao do Banco.
		/// </summary>
		public static SqlTransaction Transacao
		{
			get
			{
				return (SqlTransaction) transacao;
			}
			set
			{
				transacao = value;
			}
		}

		/// <summary>
		/// Adapter para SQL Server
		/// </summary>
		public SqlDataAdapter Adaptador
		{
			get 
			{
				this.adaptador = new SqlDataAdapter((SqlCommand) this.comando);
				this.comando.Transaction = transacao;
				return (SqlDataAdapter)this.adaptador;
			}
			set 
			{
				this.adaptador = value;
			}
		}

		/// <summary>
		/// Retorna o valor do parâmetro do arquivo de configuração XML
		/// </summary>
		/// <param name="parametro">Nome do parametro no XML</param>
		/// <returns>string</returns>
		public static string getValor(String parametro)
		{
			String dir_arquivo_configuracao = "";
			String valorRetorno=null;

			dir_arquivo_configuracao = Directory.GetCurrentDirectory() + "\\configuracao.xml";

			if(File.Exists(Directory.GetCurrentDirectory() + "\\configuracao.xml"))
				dir_arquivo_configuracao = Directory.GetCurrentDirectory() + "\\configuracao.xml";
			else
				throw new Exception ("O arquivo configuração.xml não foi localizado em " + dir_arquivo_configuracao);
	
			XmlDocument documentoXML = new XmlDocument();
			documentoXML.Load(dir_arquivo_configuracao);
			XPathNavigator navegacaoDocumento = documentoXML.CreateNavigator();

			/*********************************************************/

			XPathDocument caminhoDocumentoXml = new XPathDocument(dir_arquivo_configuracao);

			XPathNavigator navegacaoDocumentoXml = caminhoDocumentoXml.CreateNavigator();
			XPathNodeIterator iterador =  navegacaoDocumentoXml.Select("parametros/" + parametro + "/@value");							
				
			if (iterador.MoveNext())
				valorRetorno = iterador.Current.Value;
			if (valorRetorno == null)
			{
				throw new Exception("Arquivo configuracao.xml inválido!!" + 
					"\nPath: " + dir_arquivo_configuracao +
					"\nParametro:" + parametro);
			}
			return valorRetorno;
		}
	}

}
