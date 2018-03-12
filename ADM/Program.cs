using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ADM
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        /// 


        /*******************************************************************************************************************************
         *          
         *                             creation des requetes et de l'ensemble des methodes
         * 
         ********************************************************************************************************************************/


        public static MySqlConnection conn;



        /******************************* FONCTION QUI VERIFIE L'EXISTANCE DANS LA BASE DE DONNEE ADM *******************************************
         *     cette fonction renvoie true si la le matricule ou le code du exite dans la base de donnee et false dans le cas contraire
         **************************************************************************************************************************************/
        public static bool searchMat(string a)
        {
            a = a.Trim();

            try
            {
                if (a != "")
                {
                    MySqlCommand cmd1SearchMat = new MySqlCommand("select count(*) from personnel where mle = '" + a + "'", conn);

                    if (Convert.ToInt32(cmd1SearchMat.ExecuteScalar()) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception) 
            {
                return false;
            }

        }

        /************************************ FONCTION QUI VERIFIE LES MOT DE PASSE D'UN UTILISATEUR ****************************************
         *     cette fonction prend en entree le matricule et renvoie vrai si le mot de passe est correct et false dans le cas contraire
         ************************************************************************************************************************************/
        public static bool verifCod(string a)
        {
                a = a.Trim();

                if (a != "")
                {
                    MySqlCommand cmdcodVerif = new MySqlCommand("select count(*) from secretaire where mpasse like '" + a + "' ", conn);

                    if (Convert.ToInt32(cmdcodVerif.ExecuteScalar()) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                { return false;}
        }


        
















        /************************************************************************************************************************************
         *                                                          FIN
         * **********************************************************************************************************************************/


        [STAThread]
        static void Main()
        {

            try
            {
                conn = new MySqlConnection("datasource = localhost; database = adm ; userid = root ; password = ; port = 3306");
                conn.Open();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERREUR DE CONNEXION\n\nMessage: "+ Ex.Message);
            }


        }
    }
}
