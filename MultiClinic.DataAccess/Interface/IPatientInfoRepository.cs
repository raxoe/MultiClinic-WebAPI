using MultiClinic.Model.DTO;

namespace MultiClinic.DataAccess.Interface
{
    public interface IPatientInfoRepository
    {
        PatientInfoModel AddPatientInfo(PatientInfoModel model);        
        IEnumerable<PatientInfoModel> GetAllPatienInfo();
        PatientInfoModel GetPatientInfo(int id);
        bool UpdatePatienInfo(PatientInfoModel patientInfoModel);
        bool DeletePatienInfo(int id);
    }
}