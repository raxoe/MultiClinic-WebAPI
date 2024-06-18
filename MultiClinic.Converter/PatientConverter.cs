using MultiClinic.EntityFramework.EntityModel;
using MultiClinic.Model.DTO;

namespace MultiClinic.Converter
{
    public static class PatientConverter
    {
        public static PatientInfoModel ConvertEntityToModel(PatientInfo patientEntity)
        {
            try
            {
                if (patientEntity == null)
                {
                    throw new ArgumentNullException(nameof(patientEntity), "Source patientEntity cannot be null");
                }
                PatientInfoModel model = new PatientInfoModel();
                model.PatientInfoId = patientEntity.PatientInfoId;
                model.PatientName = patientEntity.PatientName;
                model.DateOfBirth = patientEntity.DateOfBirth;
                model.NRC = patientEntity.NRC;
                model.Gender = patientEntity.Gender;
                model.PatientPhone = patientEntity.PatientPhone;
                model.Email = patientEntity.Email;
                model.Address = patientEntity.Address;
                model.GuardianName = patientEntity.GuardianName;
                model.GuardianPhone = patientEntity.GuardianPhone;
                model.Notes = patientEntity.Notes;
                model.PatientType = patientEntity.PatientType;
                return model;
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }

            catch (Exception e) {
                throw ;
            }
        }
        public static PatientInfo ConvertModelToEntity(PatientInfoModel patientModel)
        {
            try
            {
                if (patientModel == null)
                {
                    throw new ArgumentNullException(nameof(patientModel), "Source patientModel cannot be null");
                }
                PatientInfo patientEntity = new PatientInfo();
                patientEntity.PatientInfoId = patientModel.PatientInfoId;
                patientEntity.PatientName = patientModel.PatientName;
                patientEntity.DateOfBirth = patientModel.DateOfBirth;
                patientEntity.NRC = patientModel.NRC;
                patientEntity.Gender = patientModel.Gender;
                patientEntity.PatientPhone = patientModel.PatientPhone;
                patientEntity.Email = patientModel.Email;
                patientEntity.Address = patientModel.Address;
                patientEntity.GuardianName = patientModel.GuardianName;
                patientEntity.GuardianPhone = patientModel.GuardianPhone;
                patientEntity.Notes = patientModel.Notes;
                patientEntity.PatientType = patientModel.PatientType;
                return patientEntity;
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }

            catch (Exception e)
            {
                throw;
            }
        }
    }
}
