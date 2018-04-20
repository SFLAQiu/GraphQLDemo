using GenFu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Model;

namespace Web.BLL {
    public class BStudent {
        private static List<MStudent> _datas = new List<MStudent>();
        public BStudent() {
            //初始化测数据
            if (_datas == null || _datas.Count <= 0) {
                GenFu.GenFu.Configure<MClass>()
                    .Fill(d => d.Id)
                    .Fill(d => d.Level).WithinRange(1, 6)
                    .Fill(d => d.Num).WithinRange(1, 10)
                    .Fill(d => d.Heads).WithinRange(50, 70);
                GenFu.GenFu.Configure<MStudent>()
                    .Fill(d => d.Id)
                    .Fill(d => d.Name).AsFirstName()
                    .Fill(d => d.Birthdate, (d) => {
                        return DateTime.Now.AddYears(d.Age * -1);
                    })
                    .Fill(d => d.Age).WithinRange(1, 10);
                _datas = GenFu.GenFu.ListOf<MStudent>(100);
            }
        }
        /// <summary>
        /// 根据id获取学生数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MStudent GetModel(int id)
            => _datas.FirstOrDefault(d => d.Id == id);
        /// <summary>
        /// 获取所有学生数据集合
        /// </summary>
        /// <returns></returns>
        public List<MStudent> GetStudents()
            => _datas;
        /// <summary>
        /// 更新学生名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UpdateName(int id,string name) {
            var mData = _datas.FirstOrDefault(d => d.Id==id);
            if (mData == null) return false;
            mData.Name = name;
            return true;
        }
        /// <summary>
        /// 根据编号获取班级信息
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public MClass GetClass(int classId) {
            if (classId <= 0) return null;
            //初始化个class对象，正常业务可能是从DB或者缓存中获取
            var mClass = GenFu.GenFu.New<MClass>();
            mClass.Id = classId;
            return mClass;
        }

    }
}