using ClosedXML.Excel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.JSInterop;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PortalUpskill.App.Utils
{
    public class FileManagerService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IJSRuntime _jsRuntime;

        public FileManagerService(IWebHostEnvironment env, IJSRuntime jsRuntime)
        {
            _env = env;
            _jsRuntime = jsRuntime;
        }

        /// <summary>
        /// sFile admite "cv" ou "foto", Id admite o Id do formando/formador/coordenador/pessoa
        /// </summary>
        /// <param name="selectedFile"></param>
        /// <param name="sFile"></param>
        /// <param name="Id"></param>
        /// <param name="sName"></param>
        /// <returns>Retorna o path em string para ser gravado na bd</returns>
        public string FilePath(IBrowserFile selectedFile, string sFile, int Id)
        {
            string path;
            if (sFile == "cv" && Path.GetExtension(selectedFile.Name).ToLower() == ".pdf")
            {
                path = Path.Combine(_env.ContentRootPath, "Files", "CV", $"{Id + selectedFile.Name}");
            }
            else if (sFile == "foto" && (Path.GetExtension(selectedFile.Name).ToLower() == ".png" || Path.GetExtension(selectedFile.Name).ToLower() == ".jpeg" || Path.GetExtension(selectedFile.Name).ToLower() == ".jpg"))
            {
                path = Path.Combine(_env.ContentRootPath, "Files", "Fotos", $"{Id + selectedFile.Name}");
            }
            else
                path = "";
            return path;
        }

        /// <summary>
        /// sFile admite "justificacao", Id admite o Id do formando, idAula admite o Id da aula
        /// </summary>
        /// <param name="selectedFile"></param>
        /// <param name="sFile"></param>
        /// <param name="Id"></param>
        /// <param name="sName"></param>
        /// <returns>Retorna o path em string para ser gravado na bd</returns>
        public string FilePath(IBrowserFile selectedFile, string sFile, int Id, int idAula)
        {
            string path;
            if (sFile == "justificacao" && Path.GetExtension(selectedFile.Name).ToLower() == ".pdf")
            {
                path = Path.Combine(_env.ContentRootPath, "Files", "Justificacoes", $"{Id + idAula + selectedFile.Name}");
            }
            else
                path = "";
            return path;
        }

        /// <summary>
        /// Cria o ficheiro na directoria sPath, admitindo o nome da turma e o id do modulo
        /// </summary>
        /// <param name="selectedFile"></param>
        /// <param name="idModulo"></param>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public string ExcelPath(IBrowserFile selectedFile, string nomeTurma, int idModulo)
        {
            string path;
            string extension = Path.GetExtension(selectedFile.Name);
            if (selectedFile != null && (Path.GetExtension(selectedFile.Name).ToLower() == ".xlsm") && nomeTurma == "" && idModulo == 0)
            {
                path = Path.Combine(_env.ContentRootPath, "Files", "Tabelas", $"formandos.xlsm");
            }
            else if (selectedFile != null && (Path.GetExtension(selectedFile.Name).ToLower() == ".xlsx" || Path.GetExtension(selectedFile.Name).ToLower() == ".xls" || Path.GetExtension(selectedFile.Name).ToLower() == ".xlsm"))
            {
                path = Path.Combine(_env.ContentRootPath, "Files", "Tabelas", $"pauta_turma_{nomeTurma}_M{idModulo}{extension}");
            }
            else
                path = "";
            return path;
        }

        public bool FileExists(string nomeTurma, int idModulo)
        {
            string path = Path.Combine(_env.ContentRootPath, "Files", "Tabelas", $"pauta_turma_{nomeTurma}_M{idModulo}.xlsm");
            return File.Exists(path);
        }

        /// <summary>
        /// Cria o ficheiro na directoria sPath
        /// </summary>
        /// <param name="selectedFile"></param>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public async Task UploadFile(IBrowserFile selectedFile, string sPath)
        {
            long fileSize = 10485760; // define o tamanho máximo do ficheiro, actualmente é de 10mb
            Stream stream = selectedFile.OpenReadStream(fileSize);
            try
            {
                Directory.CreateDirectory(Path.Combine($"{_env.ContentRootPath}", "Files", "CV"));
                Directory.CreateDirectory(Path.Combine($"{_env.ContentRootPath}", "Files", "Fotos"));
                Directory.CreateDirectory(Path.Combine($"{_env.ContentRootPath}", "Files", "Justificacoes"));
                Directory.CreateDirectory(Path.Combine($"{_env.ContentRootPath}", "Files", "Tabelas"));
            }
            catch { throw; }
            FileStream fs = File.Create(sPath);
            await stream.CopyToAsync(fs);
            stream.Close();
            fs.Close();
        }

        public static List<Formando> ReadExcel(string path)
        {
            List<Formando> formandos = new List<Formando>();

            if (path != "")
            {
                //Started reading the Excel path.
                using (XLWorkbook workbook = new XLWorkbook(path))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);

                    var row = worksheet.Row(5);
                    while (!row.Cell(1).IsEmpty())
                    {
                        Formando formando = new();
                        formando.Nome = (!row.Cell(1).IsEmpty()) ? row.Cell(1).GetValue<string>() : null;
                        if (formando.Nome == null)
                        {
                            continue;
                        }
                        formando.DataNascimento = (!row.Cell(2).IsEmpty()) ? row.Cell(2).GetValue<DateTime>() : null;
                        formando.Email = (!row.Cell(3).IsEmpty()) ? row.Cell(3).GetValue<string>() : null;
                        formando.Sexo = (!row.Cell(4).IsEmpty()) ? row.Cell(4).GetValue<string>() : null;
                        formando.NIF = (!row.Cell(5).IsEmpty()) ? row.Cell(5).GetValue<string>() : null;
                        formando.CC = (!row.Cell(6).IsEmpty()) ? row.Cell(6).GetValue<string>() : null;
                        formando.ContactoTelemovel = (!row.Cell(7).IsEmpty()) ? row.Cell(7).GetValue<string>() : null;
                        formando.ContactoTelefone = (!row.Cell(8).IsEmpty()) ? row.Cell(8).GetValue<string>() : null;
                        formando.Morada = (!row.Cell(9).IsEmpty()) ? row.Cell(9).GetValue<string>() : null;
                        formando.CP = (!row.Cell(10).IsEmpty()) ? row.Cell(10).GetValue<string>() : null;
                        formando.CodigoCNAEF = (!row.Cell(11).IsEmpty()) ? row.Cell(11).GetValue<string>() : null;
                        formando.HabilitacoesLiterarias = (!row.Cell(12).IsEmpty()) ? Convert.ToInt32(row.Cell(12).GetValue<string>()) : 0;
                        formando.Nacionalidade = (!row.Cell(13).IsEmpty()) ? row.Cell(13).GetValue<string>() : null;
                        formando.IBAN = (!row.Cell(14).IsEmpty()) ? row.Cell(14).GetValue<string>() : null;
                        formando.Bolsa = ((!row.Cell(15).IsEmpty()) && row.Cell(15).GetValue<string>() == "Sim") ? true : false;

                        formando.PerfilId = 4;
                        formando.Estado = new Estado { Id = 1 };
                        formando.EstadoId = 1;

                        formandos.Add(formando);
                        row = row.RowBelow();
                    }
                }
            }

            return formandos;
        }

        /// <summary>
        /// Converte para base64string a partir de uma directoria
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public string PathToBase64String(string sPath)
        {
            string data;
            if (sPath == "template") // download do template para importação de formandos
            {
                string templatePath = Path.Combine(_env.ContentRootPath, "Files", "template.xlsm");
                byte[] arr = File.ReadAllBytes(templatePath);
                string extension = Path.GetExtension(templatePath);
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(extension, out string contentType))
                {
                    contentType = "application/octet-stream"; // default fallback
                }
                data = $"data:{contentType};base64," + Convert.ToBase64String(arr);
            }
            else if (sPath == "pauta") // download do excel da pauta de notas
            {
                string templatePath = Path.Combine(_env.ContentRootPath, "Files", "pauta.xlsm");
                byte[] arr = File.ReadAllBytes(templatePath);
                string extension = Path.GetExtension(templatePath);
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(extension, out string contentType))
                {
                    contentType = "application/octet-stream"; // default fallback
                }
                data = $"data:{contentType};base64," + Convert.ToBase64String(arr);
            }
            else
            {
                byte[] arr = File.ReadAllBytes(sPath);
                string extension = Path.GetExtension(sPath);
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(extension, out string contentType))
                {
                    contentType = "application/octet-stream"; // default fallback
                }
                data = $"data:{contentType};base64," + Convert.ToBase64String(arr);
            }
            return data;
        }

        /// <summary>
        /// Serve para converter a pauta de notas do modulo para base64string
        /// </summary>
        /// <param name="idModulo"></param>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public string PathToBase64String(int idModulo, string turmaNome)
        {
            string sPath = Path.Combine(_env.ContentRootPath, "Files", "Tabelas", $"pauta_turma_{turmaNome}_M{idModulo}.xlsm");
            if (File.Exists(sPath))
            {
                byte[] arr = File.ReadAllBytes(sPath);
                string extension = Path.GetExtension(sPath);
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(extension, out string contentType))
                {
                    contentType = "application/octet-stream"; // default fallback
                }
                return $"data:{contentType};base64," + Convert.ToBase64String(arr);
            }
            else
            {
                return "";
            }
        }

        public static void RemoveFile(string sPath)
        {
            if (sPath != null)
            {
                File.Delete(sPath);
            }
        }

        public static bool FileExtension(InputFileChangeEventArgs e, string fileExtension)
        {
            if (e.File.Name.ToLower().EndsWith(fileExtension)) // Regex.IsMatch(e.File.Name, @"^([\w\s-_]+\.)pdf$")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Cria o ficheiro xlsx ou csv a partir do workbook
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="extension">apenas ".xlsx" ou ".csv"</param>
        /// <returns></returns>
        public async Task DownloadWorkbook(IXLWorkbook workbook, string extension = ".xlsx", string filename = null)
        {
            if (extension != ".xlsx" && extension != ".csv")
            {
                throw new ArgumentException($"Garantir que a extensão é .xlsx ou .csv");
            }

            var timestamp = Convert.ToString(DateTime.Now);

            byte[] array;

            string nomeFinal;

            if (filename != null)
            {
                nomeFinal = filename + extension;
            }
            else
            {
                nomeFinal = timestamp + "_Aulas" + extension;
            }

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                array = memoryStream.ToArray();
            }

            if (extension == ".xlsx")
            {
                await _jsRuntime.InvokeAsync<object>(
                    "SaveAsExcel",
                    nomeFinal,
                    Convert.ToBase64String(array)
                );
            }
            else if (extension == ".csv")
            {
                await _jsRuntime.InvokeAsync<object>(
                    "SaveAsCSV",
                    nomeFinal,
                    Convert.ToBase64String(array)
                );
            }
        }
    }
}