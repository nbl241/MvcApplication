using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppliacation.Filters
{
    public class CustomLogFilter : ActionFilterAttribute
    {
        private string filePath = @"F:\loggerFile.txt";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod.ToUpper() == "GET")
            {
                // initialiser le ficher
                InitFile();
                //ajouter les traces dans ce fichier
                AddTextToFile($"Méthode appellée {filterContext.HttpContext.Request.UrlReferrer} à {DateTime.UtcNow}");
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// initialiser un ficher (le creer si il n'existe pas)
        /// </summary>
        private void InitFile()
        {
            try
            {
                if (File.Exists(filePath)) return;
                using (var file = File.Create(filePath))
                    file.Close();
            }
            catch (Exception ex)
            {
                // Normalement il faut gérer les érreurs
            }
        }

        /// <summary>
        /// Ajouter du text à un fichier
        /// </summary>
        /// <param name="text"></param>
        private void AddTextToFile(string text)
        {
            File.AppendAllLines(filePath, new List<string>() { text });
            //var file = new StreamWriter(filePath);
            //file.WriteLine(text);
            //file.Write(text);
            //file.Close();
        }
    }
}
