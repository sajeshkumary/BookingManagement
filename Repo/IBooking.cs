using ServiceBookingLibrary.Models;

namespace BookingManagement.Repo
{
    public interface IBooking
    {
        public Task<Appservicerequest> AddNewRequest(Appservicerequest r);
        public Task<Appservicerequest> UpdateRequest(int requestId, Appservicerequest r);
        public void DeleteRequest(int requestId);


        public Task<List<Appservicerequest>> getAllRequests();
        public Task<Appservicerequest> getRequest(int rid);
        public Task<List<Appservicerequest>> getRequestByUserId(int uid);
        public Task<List<Appservicerequest>> getRequestByUserIdAndStatus(int uid,string status);
        public Task<List<Appservicerequest>> getRequestByStatus(string status);

        public Task<Appservicerequestreport> AddNewReport(Appservicerequestreport rp);
        public Task<List<Appservicerequestreport>> getAllReports();
        public Task<Appservicerequestreport> getReport(int rid);
        public Task<List<Appservicerequestreport>> getReportByUserId(int uid);
        public Task<List<Appservicerequestreport>> getReportByRequestId(int requestId);

    }
}
