using BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Create()
        {
            BigSchoolContext context = new BigSchoolContext();
            Course obj = new Course();
            obj.listcategory = context.Categories.ToList();
            return View(obj);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course objCourse)
        {
            BigSchoolContext context = new BigSchoolContext();
            ModelState.Remove("LecturerID");
            if (!ModelState.IsValid)
            {
                objCourse.listcategory = context.Categories.ToList();
                return View("Create", objCourse);
            }

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objCourse.LecturerID = user.Id;

            context.Courses.Add(objCourse);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
     

    }
}