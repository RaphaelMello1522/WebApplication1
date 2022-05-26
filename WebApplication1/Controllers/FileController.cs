using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services.User;

namespace WebApplication1.Controllers
{
    
    public class FileController : Controller
    {
            private readonly DatabaseContext context;
            private UsuarioService usuarioService;

        public FileController(DatabaseContext context, UsuarioService _usuarioService)
            {
                this.context = context;
                usuarioService = _usuarioService;
            }
            public async Task<IActionResult> Index()
            {
                var fileuploadViewModel = await LoadAllFiles();
                ViewBag.Message = TempData["Message"];
                ViewBag.Usuario = usuarioService.FindAll();
                return View(fileuploadViewModel);
            }
           
            [HttpPost]
            public async Task<IActionResult> UploadToDatabase(List<IFormFile> files, string description, string solicitante, string vencimento)
            {
            ViewBag.Usuario = usuarioService.FindAll();
            ViewBag.Username = new SelectList(context.Usuarios, "NomeUsuario", "NomeUsuario");
            foreach (var file in files)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var extension = Path.GetExtension(file.FileName);
                var fileModel = new FileOnDatabaseModel
                {
                    CreatedOn = DateTime.UtcNow.ToLocalTime(),
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName,
                    Description = description,
                    Solicitante = solicitante,
                    
                   
                        
                        
                    };
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        fileModel.Data = dataStream.ToArray();
                    }
                    context.FilesOnDatabase.Add(fileModel);
                    context.SaveChanges();
                }
                TempData["Message"] = "File successfully uploaded to Database";
                return RedirectToAction("Index");
            }
            
            

            private async Task<FileUploadViewModel> LoadAllFiles()
            {
            ViewBag.Username = new SelectList(context.Usuarios, "NomeUsuario", "NomeUsuario");

            var viewModel = new FileUploadViewModel();
                viewModel.FilesOnDatabase = await context.FilesOnDatabase.ToListAsync();
                return viewModel;
            }

            public async Task<IActionResult> DownloadFileFromDatabase(int id)
            {

                var file = await context.FilesOnDatabase.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (file == null) return null;
                return File(file.Data, file.FileType, file.Name + file.Extension);
            }
           
            public async Task<IActionResult> DeleteFileFromDatabase(int id)
            {

                var file = await context.FilesOnDatabase.Where(x => x.Id == id).FirstOrDefaultAsync();
                context.FilesOnDatabase.Remove(file);
                context.SaveChanges();
                TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from Database.";
                return RedirectToAction("Index");
            }
        }
    }