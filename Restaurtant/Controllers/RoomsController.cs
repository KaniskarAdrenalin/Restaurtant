using System.Linq;
using System.Web.Mvc;


namespace Restaurtant.Controllers
{
    public class RoomsController : Controller
    {
        private RestaurtantsDBContext _context = new RestaurtantsDBContext();

        // GET: Rooms
        public ActionResult Index()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Room room = _context.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(room).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Room room = _context.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Room room = _context.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Room room = _context.Rooms.Find(id);
            
            var relatedUsers = _context.Users.Where(u => u.UserID == id).ToList();
            var relatedBooking = _context.Bookings.Where(u => u.BookingID == id).ToList();
            
            foreach (var user in relatedUsers)
            {
                _context.Users.Remove(user); 
                                      
            }

            foreach (var booking in relatedBooking)
            {
                _context.Bookings.Remove(booking);
                                             
            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }
    }
}
