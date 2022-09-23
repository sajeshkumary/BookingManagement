using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBookingLibrary.Models;
using BookingManagement.Repo;
using Microsoft.AspNetCore.Authorization;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly TrainingServiceBookingContext _context;

        public BookingController(TrainingServiceBookingContext db)
        {
            _context = db;
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpPost]
        public async Task<ActionResult<Appservicerequest>> Add(Appservicerequest u)
        {
            BookingRepo bookingRepo = new BookingRepo(_context);

            return await bookingRepo.AddNewRequest(u);
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpPut("{id}")]
        public async Task<ActionResult<Appservicerequest>> UpdateRequest(int id, Appservicerequest p)
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);

                return await bookingRepo.UpdateRequest(id, p);
            }
            catch (NoRequestsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appservicerequest>>> GetAll()
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);
                return await bookingRepo.getAllRequests();
            }
            catch (NoRequestsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRequest(int id)
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);
                bookingRepo.DeleteRequest(id);
                return Ok();
            }
            catch (NoRequestsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpGet("{id}")]
        public async Task<ActionResult<Appservicerequest>> Get(int id)
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);

                return await bookingRepo.getRequest(id);
            }
            catch (NoRequestsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpGet("ByUserId/{uid}")]
        public async Task<ActionResult<List<Appservicerequest>>> GetByUserId(int uid)
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);

                return await bookingRepo.getRequestByUserId(uid);
            }
            catch (NoRequestsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpGet("ByStatus/{status}")]
        public async Task<ActionResult<List<Appservicerequest>>> GetByStatus(string status)
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);

                return await bookingRepo.getRequestByStatus(status);
            }
            catch (NoRequestsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpGet("ByUserByStatus/{id}/{status}")]
        public async Task<ActionResult<List<Appservicerequest>>> GetByUidAndStatus(int id,string status)
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);

                return await bookingRepo.getRequestByUserIdAndStatus(id,status);
            }
            catch (NoRequestsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpPost("report")]
        public async Task<ActionResult<Appservicerequestreport>> AddReport(Appservicerequestreport u)
        {
            BookingRepo bookingRepo = new BookingRepo(_context);

            return await bookingRepo.AddNewReport(u);
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpGet("report")]
        public async Task<ActionResult<IEnumerable<Appservicerequestreport>>> GetAllReports()
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);
                return await bookingRepo.getAllReports();
            }
            catch (NoReportsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpGet("ReportById/{id}")]
        public async Task<ActionResult<Appservicerequestreport>> GetReportByReportId(int id)
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);

                return await bookingRepo.getReport(id);
            }
            catch (NoReportsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpGet("ReportByUserId/{uid}")]
        public async Task<ActionResult<List<Appservicerequestreport>>> GetReportByUserId(int uid)
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);

                return await bookingRepo.getReportByUserId(uid);
            }
            catch (NoReportsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [CustomAuthFilter]
        [Authorize()]
        [HttpGet("ReportByRequestId/{rid}")]
        public async Task<ActionResult<List<Appservicerequestreport>>> GetReportByRequestId(int rid)
        {
            try
            {
                BookingRepo bookingRepo = new BookingRepo(_context);

                return await bookingRepo.getReportByRequestId(rid);
            }
            catch (NoReportsException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
