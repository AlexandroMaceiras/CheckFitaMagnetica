using System;

namespace CheckFitaMagnetica
{
	/// <summary>
	/// Classe que contem query SQL.
	/// </summary>
	public class Querys
	{
        
		/// <summary>
		/// Construtor vazio.
		/// </summary>
		public Querys()
		{			}

		/// <summary>
		/// Traz o nome da base de dados do XML.
		/// </summary>
		/// <returns></returns>
		public static string XMLDataBase1()
		{
			return Regras.getValor("CONEXAO_BD/IIRGD/CFM/INITIAL_CATALOG");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ciimag"></param>
		/// <param name="path"></param>
		/// <param name="cdsheet"></param>
		/// <returns></returns>
		public static String Query1(String cdsheet, String ciimag, String path)
		{
			String str_sql = @"select cd_sheet, path, ci_img from " + XMLDataBase1() + ".dbo.tb_img (NOLOCK) "
				+ " where ci_img = " + ciimag.ToString().Trim() 
				+ " AND cd_sheet = " + cdsheet.ToString().Trim();
			return str_sql;
		}
	}
}
