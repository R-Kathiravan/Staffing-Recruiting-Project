using Microsoft.AspNetCore.Mvc;
using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadControler : Controller
    {
        [HttpPost("UploadResume")]
        public async Task<IActionResult> UploadResume([FromForm] FileUpload fileUpload)
        {
            try
            {
                var file = fileUpload.file;
                var oldFilePath = fileUpload.oldFilePath;
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file was uploaded.");
                }

                var folderName = Path.Combine("wwwroot", "uploads", "resumes");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }

                if (!string.IsNullOrEmpty(oldFilePath))
                {
                    var oldFileName = Path.GetFileName(oldFilePath);
                    var oldPhysicalPath = Path.Combine(pathToSave, oldFileName);

                    if (System.IO.File.Exists(oldPhysicalPath))
                    {
                        System.IO.File.Delete(oldPhysicalPath);
                    }
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine(pathToSave, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var dbPath = $"/uploads/resumes/{uniqueFileName}";
                return Ok(new { Url = dbPath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
