using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CheckFitaMagnetica
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Principal : System.Windows.Forms.Form
	{
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private bool stop = false;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Principal()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Principal));
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(400, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "W:\\IIRGD - Fitas WSQ -SSP";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(416, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Abrir";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Diretório : ";
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.Location = new System.Drawing.Point(8, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(168, 24);
			this.button2.TabIndex = 3;
			this.button2.Text = "Checar a Fita Magnética";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(8, 144);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(480, 128);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Log de Erros: ";
			// 
			// richTextBox1
			// 
			this.richTextBox1.AllowDrop = true;
			this.richTextBox1.AutoSize = true;
			this.richTextBox1.AutoWordSelection = true;
			this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.richTextBox1.CausesValidation = false;
			this.richTextBox1.HideSelection = false;
			this.richTextBox1.Location = new System.Drawing.Point(16, 160);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(464, 104);
			this.richTextBox1.TabIndex = 5;
			this.richTextBox1.TabStop = false;
			this.richTextBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(8, 16);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(464, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox2);
			this.groupBox2.Location = new System.Drawing.Point(8, 88);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(480, 48);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Status: ";
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.Location = new System.Drawing.Point(184, 56);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(168, 24);
			this.button3.TabIndex = 8;
			this.button3.Text = "Parar o Processo";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button4.Location = new System.Drawing.Point(408, 280);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(80, 24);
			this.button4.TabIndex = 9;
			this.button4.Text = "Fechar";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Principal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 317);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(504, 344);
			this.MinimumSize = new System.Drawing.Size(504, 344);
			this.Name = "Principal";
			this.Text = "Checa Fita Magnética";
			this.Load += new System.EventHandler(this.Principal_Load);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Principal());
		}

		/// <summary>
		/// Abre os diretórios para pesquisa.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
			if(textBox1.Text.Length > 0)
				folderBrowserDialog1.SelectedPath = textBox1.Text;
			if(folderBrowserDialog1.ShowDialog()== DialogResult.OK)
			{
				textBox1.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		/// <summary>
		/// Faz a analise do direório que estiver indicado no campo textBox1.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(textBox1.Text.Length > 0)
				{
					folderBrowserDialog1.SelectedPath = textBox1.Text;

					DirectoryInfo di = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
					DirectoryInfo[] diretoriosDeFitas = di.GetDirectories("*");
					DirectoryInfo[] diretoriosDeFitas1 = di.GetDirectories("FITA_*");

					int quantidadeDeDiretoriosDeFitas = diretoriosDeFitas1.Length;
					int quantidadeDeDiretoriosNumericos = 0;

					textBox1.Enabled = false;
					button1.Enabled = false;
					button2.Enabled = false;

					DirectoryInfo ddd = new DirectoryInfo(@"C:\Documents and Settings\All Users\Desktop");
					
					// Se não existir Log_de_Erros_Fitas_Magnéticas.log, ele é criado aqui.
					//se existir ele é deletado e recriado.
					if(ddd.GetFiles("Log_de_Erros_Fitas_Magnéticas.log").Length.ToString() == "0")
					{
						StreamWriter writer = File.CreateText(@"C:\Documents and Settings\All Users\Desktop\Log_de_Erros_Fitas_Magnéticas.log");
						writer.Close();
					}
					else
					{
						File.Delete(@"C:\Documents and Settings\All Users\Desktop\Log_de_Erros_Fitas_Magnéticas.log");
						StreamWriter writer = File.CreateText(@"C:\Documents and Settings\All Users\Desktop\Log_de_Erros_Fitas_Magnéticas.log");
						writer.Close();
						richTextBox1.Clear();
					}

					for(int x = 1;x <= quantidadeDeDiretoriosDeFitas;x++)
					{
						if(stop == true)
							break;

						//  Conta quantos sub-diretórios tem dentro do 
						// diretório FITA_(numero) atual.
						DirectoryInfo dn = new DirectoryInfo(folderBrowserDialog1.SelectedPath + "\\FITA_" + x);
						richTextBox1.Text += " FITA_" + x + "\r\n --------------\r\n";

						escreve(" FITA_" + x + "\r\n --------------\r\n",false);

						DirectoryInfo[] diretoriosNumericos = dn.GetDirectories("*");
						quantidadeDeDiretoriosNumericos = diretoriosNumericos.Length;

						for(int y = 0;y < quantidadeDeDiretoriosNumericos;y++)
						{
							button3.Enabled = true;
							if(stop == true)
								break;

							//Conta os arquivos dentro do sub-diretório.
							DirectoryInfo dd = new DirectoryInfo(folderBrowserDialog1.SelectedPath + "\\FITA_" + x + "\\" + diretoriosNumericos[y]);
							richTextBox1.Text += " Diretório " + diretoriosNumericos[y] + " ... ";

							escreve(" " + DateTime.Now.ToString() + " ",true);
							escreve(" Diretório " + diretoriosNumericos[y] + " ... ",false);

							FileInfo[] arquivos = dd.GetFiles("*");

							// O nome do diretório FITA_... deve setar em maiúscula
							//senão não é reconhecido aqui.
							string path = folderBrowserDialog1.SelectedPath + "\\FITA_" + x + "\\" + diretoriosNumericos[y] + "\\" + diretoriosNumericos[y] + ".idx";
							bool flag = false;
							
							#region Primeira Verificação
							
							bool flagText = false;
							foreach(FileInfo fi in arquivos)
							{
								textBox2.Text = "Processando ... Conferindo arquivos no servidor: " + fi.Name.ToString();
								Application.DoEvents();

								if(stop == true)
									break;
							
								// Abre e lê o arquivo texto .idx do sub-diretório.
								using (StreamReader sr = new StreamReader(path)) 
								{
									String line;
									while ((line = sr.ReadLine()) != null) 
									{
										// Verifica se os arquivos do sub-diretório do tipo
										//.jpg, .tif ou .wsq NÃO estão listados no .idx
										if(line.IndexOf(fi.Name.ToString()) > 0)
										{
											flag = true;
											////////////////////////////////////////////////
											break;
										}
									}
								}
								if((flag != true) && (fi.Name.ToString().IndexOf(".jpg") > 0 || fi.Name.ToString().IndexOf(".tif") > 0 || fi.Name.ToString().IndexOf(".wsq") > 0))
								{
									richTextBox1.Text += "*** " + fi.Name.ToString() + " não está em " + diretoriosNumericos[y] + ".idx ! \r\n";
									escreve("*** " + fi.Name.ToString() + " não está em " + diretoriosNumericos[y] + ".idx ! \r\n",false);

									flag = false;
								}
								else
								{
									flagText = true;
								}

							}
							if(flagText)
							{
								escreve("Concluido. \r\n",true);
								flagText = false;
							}

							#endregion

							#region Segunda Verificação

							Regex r = new Regex("(;)");
							string[] s = new string[20];

							bool flagWrite = false;
							bool flagBase = false;

							using (StreamReader sr = new StreamReader(path)) 
							{
								String line;

								// Cria ArrayList com todos os arquivos do diretorio de dd.name
								ArrayList arrayArquivos = new ArrayList();
								arrayArquivos.Clear();
									
								foreach(FileInfo fisco in arquivos)
								{
									arrayArquivos.Add(fisco.Name.ToString());
								}

								escreve(" Arquivo " + diretoriosNumericos[y] + ".idx e arquivos do diretório " + diretoriosNumericos[y] + " na base.\r\n",true);

								// Inicia o loop para cada um dos arquivos do diretório dd.name
								for(int fff = 0;fff < arrayArquivos.Count;fff++)
								{
									if(stop == true)
										break;

									// Lê uma linha do .idx
									while ((line = sr.ReadLine()) != null) 
									{
										// Divide a linha lida em pedaços separados por (;)
										s = r.Split(line.ToString());

										// Traz o nome dos arquivos .jpg etc que vem no .idx
										for(int ff = 1;ff < s.Length;ff+=3)
										{
											if(stop == true)
												break;

											if(s[ff].ToString().Trim() != ";")
											{
												textBox2.Text = "Processando ... Conferindo arquivos em " + diretoriosNumericos[y] + ".idx : " + s[ff].ToString();
												Application.DoEvents();

												if(stop == true)
													break;

												// Verifica se o diretório atual (y) tem o arquivo do s[ff] do .idx
												if(arrayArquivos.IndexOf(s[ff].ToString().Trim()) < 0)
												{
													//MessageBox.Show(s[ff].ToString().Trim());
													if(s[ff].ToString().Trim().IndexOf(".jpg") > 0 || s[ff].ToString().Trim().IndexOf(".tif") > 0 || s[ff].ToString().Trim().IndexOf(".wsq") > 0)
													{
														escreve("*** " + s[ff].ToString().Trim() + " não está no diretório " + diretoriosNumericos[y] + "\r\n", true);
													}
													break;
												}
												else
												{ 
													flagWrite = true;
												}

												textBox2.Text = "Processando ... Conferindo " + diretoriosNumericos[y] + ".idx e registros na base, arquivos de " + diretoriosNumericos[y] + " : " + s[ff].ToString();
												Application.DoEvents();

												// Tira qualquer tipo de caracter extra que venha junto com
												//o cd_sheet, path e ci_img.
												if(s[0].Length > 7)
												{
													s[0] = s[0].Substring(s[0].Length-7,7);
													escreve("*** O cd_sheet " + s[0].ToString().Trim() + " está  com caracteres extras no " + diretoriosNumericos[y] + ".idx\r\n",true);
												}
												if(s[2].Length > 1)
												{
													s[2] = s[2].Substring(s[2].Length-1,1);
													escreve("*** " + s[2].ToString().Trim() + " está  com caracteres extras no " + diretoriosNumericos[y] + ".idx\r\n",true);
												}
												if(s[4].Length > 11)
												{
													s[4] = s[4].Substring(s[4].Length-11,11);
													escreve("*** " + s[4].ToString().Trim() + " está  com caracteres extras no " + diretoriosNumericos[y] + ".idx\r\n",true);
												}

												// Verifica na base a existência do cd_sheet, path e ci_img 
												String pathCorreto =  dd.Name + "\\" + s[4].ToString().Substring(0,s[4].ToString().IndexOf("."));
												Regras.ExportarParaConsultar(s[0].ToString(), s[2].ToString(), pathCorreto);

												Regras regras = new Regras();

												try
												{
													regras.IniciarTransacao("SQL SERVER","IIRGD","CFM");

													if(!regras.metodoPesquisarCdsheet())
													{
														escreve("*** O cd_sheet " + s[0].ToString().Trim() + " não está na base de dados " + diretoriosNumericos[y] + "\r\n", true);
													}
													else
													{
														flagBase = true;
													}
													regras.SubmeterTransacao();
												}
												catch(Exception Ex) 
												{
													regras.DesfazerTransacao();
													throw new Exception(Ex.Message);
												}		
											}
										}
									}
								}
								
								if(flagWrite)
								{
									escreve(" Arquivo .idx concluido. \r\n",true);
									flagWrite = false;
								}
								if(flagBase)
								{
									escreve(" Arquivos do diretório " + diretoriosNumericos[y] + " na base concluido.\r\n", true);
								}
								escreve("---------------------------------------------------------------------\r\n",true);
							}
							#endregion

						}
					}
					if(quantidadeDeDiretoriosDeFitas == 0)
					{
						MessageBox.Show("Escolha o diretório raiz correto onde ficam TODOS os sub-diretórios das fitas.","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Information);
						stop = true;
					}
					else
					{
						if(stop == false)
						{
							escreve("Fim do log.",true);
							MessageBox.Show("O arquivo texto com os RG´s listados foi criado no Desktop\r\ncom o nome de: Log_de_Erros_Fitas_Magnéticas.log" ,"Log de Erros",MessageBoxButtons.OK,MessageBoxIcon.Information);

						}
						stop = false;
					}
					textBox1.Enabled = true;
					button1.Enabled = true;
					button2.Enabled = true;
					button3.Enabled = false;
				}
				else
				{
					MessageBox.Show("Selecione o diretório SSP na rede ou no HD antes de clicar em 'Checar a Fita Magnética' !","Checar a Fita Magnética",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Método que escreve linha de string no log.
		/// </summary>
		/// <param name="log">String a ser escrita no log</param>
		/// <param name="telaFalseTtrue">Imprimir na tela ou só no log. True -> Tela também.</param>
		private void escreve(String log, bool telaFalseTtrue)
		{
			StreamWriter writer = File.AppendText(@"C:\Documents and Settings\All Users\Desktop\Log_de_Erros_Fitas_Magnéticas.log");
			writer.Write(log);
			writer.WriteLine();
			writer.Close();
			if(telaFalseTtrue)
				richTextBox1.Text += log;
		}

		/// <summary>
		/// Fechar o programa.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, System.EventArgs e)
		{
			stop = true;
			this.Close();
		}

		/// <summary>
		/// Parar/Reiniciar o processo.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, System.EventArgs e)
		{
			if(
				MessageBox.Show
				(
				 "Interromper o processo terá de reiniciar tudo novamente.\r\nTem certeza?"
				,"Interromper o Processo"
				,MessageBoxButtons.YesNo
				,MessageBoxIcon.Question
				,MessageBoxDefaultButton.Button2
				,MessageBoxOptions.ServiceNotification
				) == DialogResult.Yes
				)
			{
				stop = true;
				button3.Enabled = false;
				textBox1.Enabled = true;
				button1.Enabled = true;
				button2.Enabled = true;
			}
		}

		/// <summary>
		/// Inicio
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Principal_Load(object sender, System.EventArgs e)
		{
			//Ao iniciar a classe o botão para parar está desabilitado.
			button3.Enabled = false;
		}

	}
}
