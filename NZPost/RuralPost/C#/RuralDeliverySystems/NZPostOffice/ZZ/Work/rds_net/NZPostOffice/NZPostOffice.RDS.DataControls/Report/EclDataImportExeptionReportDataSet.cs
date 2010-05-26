using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class REclDataImportExeptionReport
    {
        public int EclBatchNo
        {
            get
            {
                return 0;
            }
        }

        public string EclTicketNo
        {
            get
            {
                return string.Empty;
            }
        }

        public string EclTicketPart
        {
            get
            {
                return string.Empty;
            }
        }

        public string EclCustomerName
        {
            get
            {
                return string.Empty;
            }
        }

        public int EclCustomerCode
        {
            get
            {
                return 0;
            }
        }

        public int EclSeq
        {
            get
            {
                return 0;
            }
        }

        public int EclDriverId
        {
            get
            {
                return 0;
            }
        }

        public int EclRateCode
        {
            get
            {
                return 0;
            }
        }

        public string EclRateDescr
        {
            get
            {
                return string.Empty;
            }
        }

        public string EclPkgDescr
        {
            get
            {
                return string.Empty;
            }
        }

        public int EclBatchId
        {
            get
            {
                return 0;
            }
        }

        public int EclRunId
        {
            get
            {
                return 0;
            }
        }

        public string EclRunNo
        {
            get
            {
                return string.Empty;
            }
        }

        public DateTime EclDriverDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }

        public DateTime EclDateEntered
        {
            get
            {
                return DateTime.MinValue;
            }
        }

        public string EclTicketPayable
        {
            get
            {
                return string.Empty;
            }
        }

        public string EclRuralPayable
        {
            get
            {
                return string.Empty;
            }
        }

        public int EclScanCount
        {
            get
            {
                return 0;
            }
        }

        public string EclSigReqFlag
        {
            get
            {
                return string.Empty;
            }
        }

        public string EclSigCaptured
        {
            get
            {
                return string.Empty;
            }
        }

        public string EclSigName
        {
            get
            {
                return string.Empty;
            }
        }

        public string EclPrCode
        {
            get
            {
                return string.Empty;
            }
        }

        public string ErrorMsgText
        {
            get
            {
                return string.Empty;
            }
        }
    }

    public class EclDataImportExeptionReportDataSet : ReportDataSet<EclDataImportExeptionReport>
    {

        public DataColumn EclBatchNo = new DataColumn("EclBatchNo", typeof(int));

        public DataColumn EclTicketNo = new DataColumn("EclTicketNo", typeof(string));

        public DataColumn EclTicketPart = new DataColumn("EclTicketPart", typeof(string));

        public DataColumn EclCustomerName = new DataColumn("EclCustomerName", typeof(string));

        public DataColumn EclCustomerCode = new DataColumn("EclCustomerCode", typeof(int));

        public DataColumn EclSeq = new DataColumn("EclSeq", typeof(int));

        public DataColumn EclDriverId = new DataColumn("EclDriverId", typeof(int));

        public DataColumn EclRateCode = new DataColumn("EclRateCode", typeof(int));

        public DataColumn EclRateDescr = new DataColumn("EclRateDescr", typeof(string));

        public DataColumn EclPkgDescr = new DataColumn("EclPkgDescr", typeof(string));

        public DataColumn EclBatchId = new DataColumn("EclBatchId", typeof(int));

        public DataColumn EclRunId = new DataColumn("EclRunId", typeof(int));

        public DataColumn EclRunNo = new DataColumn("EclRunNo", typeof(string));

        public DataColumn EclDriverDate = new DataColumn("EclDriverDate", typeof(DateTime));

        public DataColumn EclDateEntered = new DataColumn("EclDateEntered", typeof(DateTime));

        public DataColumn EclTicketPayable = new DataColumn("EclTicketPayable", typeof(string));

        public DataColumn EclRuralPayable = new DataColumn("EclRuralPayable", typeof(string));

        public DataColumn EclScanCount = new DataColumn("EclScanCount", typeof(int));

        public DataColumn EclSigReqFlag = new DataColumn("EclSigReqFlag", typeof(string));

        public DataColumn EclSigCaptured = new DataColumn("EclSigCaptured", typeof(string));

        public DataColumn EclSigName = new DataColumn("EclSigName", typeof(string));

        public DataColumn EclPrCode = new DataColumn("EclPrCode", typeof(string));

        public DataColumn ErrorMsgText = new DataColumn("ErrorMsgText", typeof(string));

        public EclDataImportExeptionReportDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				EclBatchNo,EclTicketNo,EclTicketPart,EclCustomerName,EclCustomerCode
               ,EclSeq,EclDriverId,EclRateCode,EclRateDescr,EclPkgDescr,EclBatchId
               ,EclRunId,EclRunNo,EclDriverDate,EclDateEntered,EclTicketPayable
               ,EclRuralPayable,EclScanCount,EclSigReqFlag,EclSigCaptured,EclSigName
               ,EclPrCode,ErrorMsgText
			});
            EclBatchNo.AllowDBNull = true;
            EclTicketNo.AllowDBNull = true;
            EclTicketPart.AllowDBNull = true;
            EclCustomerName.AllowDBNull = true;
            EclCustomerCode.AllowDBNull = true;
            EclSeq.AllowDBNull = true;
            EclDriverId.AllowDBNull = true;
            EclRateCode.AllowDBNull = true;
            EclRateDescr.AllowDBNull = true;
            EclPkgDescr.AllowDBNull = true;
            EclBatchId.AllowDBNull = true;
            EclRunId.AllowDBNull = true;
            EclRunNo.AllowDBNull = true;
            EclDriverDate.AllowDBNull = true;
            EclDateEntered.AllowDBNull = true;
            EclTicketPayable.AllowDBNull = true;
            EclRuralPayable.AllowDBNull = true;
            EclScanCount.AllowDBNull = true;
            EclSigReqFlag.AllowDBNull = true;
            EclSigCaptured.AllowDBNull = true;
            EclSigName.AllowDBNull = true;
            EclPrCode.AllowDBNull = true;
            ErrorMsgText.AllowDBNull = true;
        }

        public EclDataImportExeptionReportDataSet(object dataSource) : this()
        {
            Metex.Core.EntityBindingList<EclDataImportExeptionReport> datas = dataSource as Metex.Core.EntityBindingList<EclDataImportExeptionReport>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(EclDataImportExeptionReport data)
        {
            DataRow row = this.NewRow();
            row["EclBatchNo"] = GetFieldValue(data.EclBatchNo);
            row["EclTicketNo"] = GetFieldValue(data.EclTicketNo);
            row["EclTicketPart"] = GetFieldValue(data.EclTicketPart);
            row["EclCustomerName"] = GetFieldValue(data.EclCustomerName);
            row["EclCustomerCode"] = GetFieldValue(data.EclCustomerCode);
            row["EclSeq"] = GetFieldValue(data.EclSeq);
            row["EclDriverId"] = GetFieldValue(data.EclDriverId);
            row["EclRateCode"] = GetFieldValue(data.EclRateCode);
            row["EclRateDescr"] = GetFieldValue(data.EclRateDescr);
            row["EclPkgDescr"] = GetFieldValue(data.EclPkgDescr);
            row["EclBatchId"] = GetFieldValue(data.EclBatchId);
            row["EclRunNo"] = GetFieldValue(data.EclRunNo);
            row["EclDriverDate"] = GetFieldValue(data.EclDriverDate);
            row["EclDateEntered"] = GetFieldValue(data.EclDateEntered);
            row["EclTicketPayable"] = GetFieldValue(data.EclTicketPayable);
            row["EclRuralPayable"] = GetFieldValue(data.EclRuralPayable);
            row["EclScanCount"] = GetFieldValue(data.EclScanCount);
            row["EclSigReqFlag"] = GetFieldValue(data.EclSigReqFlag);
            row["EclSigCaptured"] = GetFieldValue(data.EclSigCaptured);
            row["EclSigName"] = GetFieldValue(data.EclSigName);
            row["EclPrCode"] = GetFieldValue(data.EclPrCode);
            row["ErrorMsgText"] = GetFieldValue(data.ErrorMsgText);

            return row;
        }
    }
}
