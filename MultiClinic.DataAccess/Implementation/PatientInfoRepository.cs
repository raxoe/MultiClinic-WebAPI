using Microsoft.EntityFrameworkCore;
using MultiClinic.Converter;
using MultiClinic.DataAccess.Interface;
using MultiClinic.EntityFramework;
using MultiClinic.EntityFramework.EntityModel;
using MultiClinic.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiClinic.DataAccess.Implementation
{
    internal class PatientInfoRepository : IPatientInfoRepository
    {
        private readonly DbMultiClinicContext _dbMultiClinicContext;
        public PatientInfoRepository(DbMultiClinicContext dbMultiClinicContext)
        {
            _dbMultiClinicContext = dbMultiClinicContext;
        }

        public PatientInfoModel AddPatientInfo(PatientInfoModel model)
        {
            try
            {
                PatientInfo patientInfo = PatientConverter.ConvertModelToEntity(model);
                _dbMultiClinicContext.Add(patientInfo);
                _dbMultiClinicContext.SaveChanges();

                model.PatientInfoId = patientInfo.PatientInfoId;
                return model;
            }
            catch (Exception ex)
            {
                //log
                throw;
            }
        }

        public IEnumerable<PatientInfoModel> GetAllPatienInfo()
        {
            try
            {
                return _dbMultiClinicContext.PatientInfos.AsEnumerable().Select(x => PatientConverter.ConvertEntityToModel(x)).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PatientInfoModel GetPatientInfo(int id)
        {
            PatientInfoModel result;
            try
            {
                result = PatientConverter.ConvertEntityToModel(_dbMultiClinicContext.PatientInfos.FirstOrDefault(x => x.PatientInfoId == id));
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public bool UpdatePatienInfo(PatientInfoModel patientInfoModel)
        {
            bool result = false;
            try
            {
                PatientInfo entity = _dbMultiClinicContext.PatientInfos.FirstOrDefault(x => x.PatientInfoId == patientInfoModel.PatientInfoId);
                if (entity == null)
                {
                    return result;
                }

                PatientConverter.ConvertModelToEntity(patientInfoModel);
                _dbMultiClinicContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public bool DeletePatienInfo(int id)
        {
            bool result = false;
            try
            {
                var patientInfo = _dbMultiClinicContext.PatientInfos.FirstOrDefault(x => x.PatientInfoId == id);
                if (patientInfo == null)
                {
                    return result;
                }
                _dbMultiClinicContext.PatientInfos.Remove(patientInfo);
                _dbMultiClinicContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

    }
}
