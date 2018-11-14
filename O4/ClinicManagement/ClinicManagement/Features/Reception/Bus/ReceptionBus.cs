using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Features.Reception.Bus
{
    public class ReceptionBus: Common.ClinicBus
    {
        static public ReceptionBus SharedInstance
        {
            get
            {
                if (sharedInstance == null)
                    sharedInstance = new ReceptionBus();
                return sharedInstance;
            }
        }
        protected ReceptionBus(){}

        public void fetchListBenhNhan(Action<List<DTO.BenhNhanEnity>, List<COM.MessageError>, string> completion)
        {
            var listResult = new List<DTO.BenhNhanEnity>();
            var listMessageError = new List<COM.MessageError>();
            var result = this.benhNhanBus.GetListBenhNhan(out listResult, ref listMessageError);
            completion(listResult, listMessageError, result);
        }

        static protected ReceptionBus sharedInstance;

        private BUS.Imp.BenhNhanImplement benhNhanBus = new BUS.Imp.BenhNhanImplement();
    }
}
