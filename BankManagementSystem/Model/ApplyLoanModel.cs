using BankManagementSystem.CommandsandNotify;
using System.Collections.Generic;
using System.Linq;

namespace BankManagementSystem.Model
{
    public class ApplyLoanModel : Notifier
    {
        #region private Members

        private Dictionary<string, string> propertyErrors;

        private string loanType;

        private string loanAmount;

        private string loanDate;

        private string roi;

        private string loanDuration;

        private string warning;

        private string status;

        #endregion

        #region Public Members
        public Dictionary<string, string> PropertyErrors
        {
            get { return propertyErrors; }
            set { propertyErrors = value; }
        }

        public string LoanType
        {
            get { return loanType; }
            set { loanType = value; Notify(); }
        }

        public string LoanAmount
        {
            get { return loanAmount; }
            set
            {
                loanAmount = value; Notify();
                ClearErrors(LoanAmount);
                if (LoanAmount.Any(char.IsLetter) || LoanAmount.Any(char.IsSymbol) || LoanAmount.Any(char
                    .IsPunctuation)) AddError(nameof(LoanAmount), "Loan Amount Should be numbers only");
            }
        }

        public string LoanDate
        {
            get { return loanDate; }
            set
            {
                loanDate = value;
                Notify();
                
            }
        }

        public string ROI
        {
            get { return roi; }
            set
            {
                roi = value; Notify(); Notify();
                ClearErrors();
                if (ROI.Any(char.IsLetter) || ROI.Any(char.IsSymbol))
                    AddError(nameof(ROI), "Loan Amount Should be numbers only");

            }
        }

        public string LoanDuration
        {
            get { return loanDuration; }
            set
            {
                loanDuration = value; Notify();
                if (LoanAmount.Any(char.IsLetter) || LoanAmount.Any(char.IsSymbol) || LoanAmount.Any(char
                        .IsPunctuation)) AddError(nameof(LoanAmount), "Loan Duration Should be numbers only");
            }
        }

        public string Warning
        {
            get { return warning; }
            set { warning = value; Notify(); }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value; Notify();
            }
        }
        #endregion
    }
}
