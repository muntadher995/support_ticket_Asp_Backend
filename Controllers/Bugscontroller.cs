using BugProject.Dtos.Bugs;
using BugProject.Interfaces;
using BugProject.Mappers;
using BugProject.Models;
using BugProject.Repositry;
using FinanceProject.Data;
using FinanceProject.Dtos.Accont;
using FinanceProject.Interfaces;
using FinanceProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugProject.Controllers
{
    [Route("api/Bugscontroller")]
    [ApiController]
    public class Bugscontroller : ControllerBase
    {
        private readonly UserManager<Users> _usermanager;
        private readonly IBugs _bugsRepo;
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Bugscontroller(AppDBContext context, IBugs bugsRepo, IWebHostEnvironment hostingEnvironment, UserManager<Users> usermanager)
        {
            _usermanager= usermanager;
            _bugsRepo = bugsRepo;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet("Get All")]

        public async Task<IActionResult> getBugsAsync()


        {


            var bg =  _context.bugs.Include(b => b.Bug_Atachment).ToList();
            return Ok(bg);
        }




        LoginDto logindto;


        [HttpPost("Add Bug With Image")]
        public async Task<ActionResult<Bugs>> CreateBugsWithImage([FromForm] NewBugsDto newbugDto)
        {
            if (newbugDto.FilePaths == null || !newbugDto.FilePaths.Any())
            {
                return BadRequest("At least one image file is required.");
            }

            // var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var filePaths = new List<string>();

            foreach (var imageFile in newbugDto.FilePaths)
            {

                var fileName = Path.GetFileName(imageFile.FileName);
                // var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);






                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // filePaths.Add("/uploads/" + fileName);
                filePaths.Add(fileName);


            }
           


            var userAgent = Request.Headers["User-Agent"].ToString();

            //var user = _usermanager.Users.FirstOrDefault(u => u.UserName == logindto.Username.ToString());



            // Combine all paths into a single string, separated by a delimiter (e.g., ";")
            var combinedFilePaths = string.Join(",", filePaths);

            // Create the Employee and EmployeeImage models
            var bugsmdl = new Bugs
            {


                Title = newbugDto.Title,

                Description = newbugDto.Description,




                SystemName = newbugDto.SystemName,


              //  UserName = user,

                 UserName = newbugDto.UserName,



                UserAgaint = userAgent,

                CreateAt = newbugDto.CreateAt,

                UpdateAt = newbugDto.UpdateAt,
                ActiveState = newbugDto.ActiveState,
                Status = newbugDto.Status,

                Bug_Atachment = new Bug_Atachment
                {
                    ImagePaths = combinedFilePaths,
                }

            };

            // Add and save the employee and their image paths to the database
            _context.bugs.Add(bugsmdl);
            await _context.SaveChangesAsync();
            return Ok(bugsmdl);


        }






















        [HttpGet("Get by Id")]
        public async Task<IActionResult> GetBug(int id)
        {


            var bg = _context.bugs.Include(b => b.Bug_Atachment).FirstOrDefault(b => b.Id == id);
           

            //var bug = await _context.bugs.FindAsync(id);

            if (bg == null)
            {
                return NotFound();
            }



            return Ok(bg);
        }



        

         

        // PUT api/<Bugscontroller>/5
        [HttpPut("Update")]


        public async Task<ActionResult<Bugs>> BugUpdate(int id, [FromForm] NewBugsDto newbugDto)
        {


            var bg = _context.bugs.Include(b => b.Bug_Atachment).FirstOrDefault(b => b.Id == id);


            //var bug = await _context.bugs.FindAsync(id);

            if (bg == null)
            {
                return NotFound();
            }


            if (newbugDto.FilePaths == null || !newbugDto.FilePaths.Any())
            {
                return BadRequest("At least one image file is required.");
            }

            // var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var filePaths = new List<string>();

            foreach (var imageFile in newbugDto.FilePaths)
            {

                var fileName = Path.GetFileName(imageFile.FileName);
                // var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);






                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // filePaths.Add("/uploads/" + fileName);
                filePaths.Add(fileName);


            }



            var userAgent = Request.Headers["User-Agent"].ToString();

            //var user = _usermanager.Users.FirstOrDefault(u => u.UserName == logindto.Username.ToString());



            // Combine all paths into a single string, separated by a delimiter (e.g., ";")
            var combinedFilePaths = string.Join(",", filePaths);







            bg.Title = newbugDto.Title;

            bg.Description = newbugDto.Description;




           bg. SystemName = newbugDto.SystemName;


            //  UserName = user,

            bg.UserName = newbugDto.UserName;



            bg.UserAgaint = userAgent;

           bg. CreateAt = newbugDto.CreateAt;

            bg.UpdateAt = newbugDto.UpdateAt;
            bg.ActiveState = newbugDto.ActiveState;
            bg.Status = newbugDto.Status;

            bg.Bug_Atachment.ImagePaths = combinedFilePaths;
            
            /*
            Bug_Atachment = new Bug_Atachment
                {
                    ImagePaths = combinedFilePaths,
                }
            */

            await _context.SaveChangesAsync( );
     
            

            return Ok(bg);



           // return Ok(bg);
        }

        // DELETE api/<Bugscontroller>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBug(int id)
        {


            var bg = _context.bugs.FirstOrDefault(b => b.Id == id);


            //var bug = await _context.bugs.FindAsync(id);

            if (bg == null)
            {
                return NotFound();
            }
            _context.bugs.Remove(bg); 

            await _context.SaveChangesAsync();

            return Ok("item is removed");
        }
    }
}
