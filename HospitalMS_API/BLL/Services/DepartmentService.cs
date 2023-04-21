using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DepartmentService
    {
        public static List<DeptDocStaffDTO> Get()
        {
            var data = DataAccessFactory.DepartmentData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Department, DeptDocStaffDTO>();
                    c.CreateMap<Doctor, DoctorDTO>();
                    c.CreateMap<Staff, StaffDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<DeptDocStaffDTO>>(data);
                return mapped;
            }
            return null;
        }
        //public static DeptDocStaffDTO Get(int id)
        //{
        //    var data = DataAccessFactory.DepartmentData().Get(id);
        //    if (data != null)
        //    {
        //        var cfg = new MapperConfiguration(c =>
        //        {
        //            c.CreateMap<Department, DeptDocStaffDTO>();
        //            c.CreateMap<Doctor, DoctorDTO>();
        //            // c.CreateMap<Staff, StaffDTO>();
        //        });
        //        var mapper = new Mapper(cfg);
        //        var mapped = mapper.Map<DeptDocStaffDTO>(data);
        //        return mapped;
        //    }
        //    return null;
        //}
        public static DepartmentDTO Get(int id)
        {
            var data = DataAccessFactory.DepartmentData().Get(id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Department, DepartmentDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<DepartmentDTO>(data);
            }
            return null;
        }

        public static bool Create(DepartmentDTO dept)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DepartmentDTO, Department>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Department>(dept);
            var res = DataAccessFactory.DepartmentData().Create(mapped);
            return (res != null);
        }
        public static bool Update(DepartmentDTO dept)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DepartmentDTO, Department>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Department>(dept);
            var res = DataAccessFactory.DepartmentData().Update(mapped);
            return (res != null) ? true : false;

        }
    }
}
