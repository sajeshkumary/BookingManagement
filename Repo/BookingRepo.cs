using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceBookingLibrary.Models;

namespace BookingManagement.Repo
{

    public class BookingRepo : IBooking
    {

        private readonly TrainingServiceBookingContext _context;

        public BookingRepo(TrainingServiceBookingContext db)
        {
            _context = db;
        }

        public async Task<Appservicerequest> AddNewRequest(Appservicerequest r)
        {
            _context.Appservicerequests.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }

        public async Task<Appservicerequest> UpdateRequest(int requestId, Appservicerequest r)
        {
            Appservicerequest req = _context.Appservicerequests.Find(requestId);

            if (req != null)
            {
                _context.Entry(r).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return r;
            }
            else
            {
                throw new NoRequestsException("No Request with Search Critera");
            }

        }

        public void DeleteRequest(int ProductId)
        {
            Appservicerequest req = _context.Appservicerequests.Find(ProductId);

            if (req != null)
            {
                _context.Remove(req);
                _context.SaveChangesAsync();

            }
            else
            {
                throw new NoProductsException("No Request with Search Critera");
            }

        }

        public async Task<List<Appservicerequest>> getAllRequests()
        {
            var requests = await _context.Appservicerequests.ToListAsync();
            if (requests == null || requests.Count() == 0)
            {
                throw new NoRequestsException("No Requests");
            }
            else
            {
                return requests;
            }
        }

        public async Task<Appservicerequest> getRequest(int rId)
        {
            var request = await _context.Appservicerequests.FindAsync(rId);
            if (request == null)
            {
                throw new NoRequestsException("No Requwst with Search Critera");
            }
            else
            {
                return request;
            }
        }

        public async Task<List<Appservicerequest>> getRequestByUserId(int uid)
        {
            var requests = await _context.Appservicerequests.Where(r=>r.Userid==uid).ToListAsync();
            if (requests == null || requests.Count() == 0)
            {
                throw new NoRequestsException("No Requests by you");
            }
            else
            {
                return requests;
            }
        }

        public async Task<List<Appservicerequest>> getRequestByStatus(string status)
        {
            var requests = await _context.Appservicerequests.Where(r => r.Status == status).ToListAsync();
            if (requests == null || requests.Count() == 0)
            {
                throw new NoRequestsException("No Requests with this status");
            }
            else
            {
                return requests;
            }
        }
        
        public async Task<List<Appservicerequest>> getRequestByUserIdAndStatus( int uId, string status)
        {
            var requests = await _context.Appservicerequests.Where(r => r.Userid==uId &&
                            r.Status == status).ToListAsync();
            if (requests == null || requests.Count() == 0)
            {
                throw new NoRequestsException("No Requests by you with this status");
            }
            else
            {
                return requests;
            }
        }

        public async Task<Appservicerequestreport> AddNewReport(Appservicerequestreport rp)
        {
            _context.Appservicerequestreports.Add(rp);
            await _context.SaveChangesAsync();
            return rp;
        }

        public async Task<List<Appservicerequestreport>> getAllReports()
        {
            var reports = await _context.Appservicerequestreports.ToListAsync();
            if (reports == null || reports.Count() == 0)
            {
                throw new NoReportsException("No Reports");
            }
            else
            {
                return reports;
            }
        }

        public async Task<Appservicerequestreport> getReport(int rId)
        {
            var report = await _context.Appservicerequestreports.FindAsync(rId);
            if (report == null)
            {
                throw new NoRequestsException("No Report with Search Critera");
            }
            else
            {
                return report;
            }
        }

        public async Task<List<Appservicerequestreport>> getReportByUserId(int uid)
        {
            var reports = await _context.Appservicerequestreports.Where(r => r.Servicereq.Userid == uid).ToListAsync();
            if (reports == null || reports.Count() == 0)
            {
                throw new NoRequestsException("No Reports by you");
            }
            else
            {
                return reports;
            }
        }
        
        public async Task<List<Appservicerequestreport>> getReportByRequestId(int reqId)
        {
            var reports = await _context.Appservicerequestreports.Where(r => r.Servicereq.Id == reqId).ToListAsync();
            if (reports == null || reports.Count() == 0)
            {
                throw new NoRequestsException("No Reports For This Request");
            }
            else
            {
                return reports;
            }
        }

    }
}
