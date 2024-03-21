using System.ComponentModel.DataAnnotations;

namespace BankManagementApi.Model
{
    public class LoanDeatailDto
    {
        public int LoanId { get; set; }
        public string UserName { get; set; }
        public string LoanType { get; set; }
        public double LoanAmount { get; set; }
        public DateTime LoanDate { get; set; }
        public float RateOfInterst { get; set; }
        public int LoanDuration { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
    }
}
