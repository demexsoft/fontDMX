using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data;
using System.Data.SqlClient;
using betaCulturalMARKII.conexionMysql;

namespace betaCulturalMARKII
{
    public class cls_Utilerias
    {
        private int intOpc;

        public int OpcionMenu
        {
            get { return intOpc; }
            set { intOpc = value; }
        }

        public void ShowMsg(Control crt, string Mensaje)
        {
            try
            {
                string Msg = "alert('" + Mensaje + "')";
                ScriptManager.RegisterClientScriptBlock(crt, typeof(Page), "msg", Msg, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool EnviaMail(string Correos, string Asunto , string Mensaje)
        {
            bool Resp = false;

            try
            {
                char delimitantes = ';';
                string[] ListaCorreos = Correos.Split(delimitantes);
                //string[] ListaArchivos = Archivos.Split(delimitantes);

                if (ListaCorreos.Length != 0)
                {
                    MailMessage Msg = new MailMessage();

                    //  Direccion de correos a los que se les enviara el mensaje.                    
                    for (int i = 0; i < ListaCorreos.Length; i++)
                    {
                        Msg.To.Add(new MailAddress(ListaCorreos[i]));
                    }


                    //  Direccion de correo y nombre "Correo DXM" del que envia el mensaje.
                    Msg.From = new MailAddress("dmx.correo@gmail.com", "Correo DMX", System.Text.Encoding.UTF8);

                    //  Asunto del Mensaje
                    //Msg.Subject = "Asunto del Mensaje";
                    Msg.Subject = Asunto;
                    Msg.SubjectEncoding = System.Text.Encoding.UTF8;

                    //  Mensaje.
                    //Msg.Body = "Contenido del Mensaje";
                    Msg.Body = Mensaje;
                    Msg.BodyEncoding = System.Text.Encoding.UTF8;
                    Msg.IsBodyHtml = false;

                    //  Ruta del archivo adjunto.                    
                    //if (!string.IsNullOrEmpty(ListaArchivos.ToString())) 
                    //{
                    //    Attachment[] ArchivoAdj = new Attachment[ListaArchivos.Length];
                    //    for (int j = 0; j < ListaArchivos.Length; j++)
                    //    {
                    //        ArchivoAdj[j] = new Attachment(ListaArchivos[j]);
                    //        Msg.Attachments.Add(ArchivoAdj[j]);                                                        
                    //    }                        
                    //}

                    //  Este es el paso mas importante porque aqui van los datos del servidor de correo
                    //  que despachara el envio de correos
                    SmtpClient ClienteSMTP = new SmtpClient();

                    //  Este es el correo encargado del envio "Lo puedes abrir lo cree en GMAIL"
                    ClienteSMTP.Credentials = new NetworkCredential("dmx.correo@gmail.com", "d3m3s0ft");
                    ClienteSMTP.Host = "smtp.gmail.com";
                    ClienteSMTP.Port = 587;
                    ClienteSMTP.EnableSsl = true;
                    ClienteSMTP.Send(Msg);

                    Resp = true;
                    //MessageBox.Show("Mail enviado¡¡¡");
                }
            }
            catch (Exception ex)
            {
                Resp = false;
                throw new Exception(ex.Message);
            }

            return Resp;
        }

        public DataSet opcMenu(int IdPerfil)
        {
            cls_acceso_dataMySql accesoMysql = new cls_acceso_dataMySql();
            DataSet ds = new DataSet();

            try
            {
                SqlParameter[] parametroMySql = new SqlParameter[1];
                parametroMySql[0] = new SqlParameter("@IDPerfil", SqlDbType.Int);
                parametroMySql[0].Value = IdPerfil;
                

                ds = accesoMysql.fn_getResultado_DataSet(parametroMySql, "getMenusXPerfil");
                return ds;
            }
            catch (Exception ex_)
            {
                cls_errores.muestraWebError(ex_);
                return ds = new DataSet();
            }
        }
    }
}