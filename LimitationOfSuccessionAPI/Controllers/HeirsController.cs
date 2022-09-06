using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LimitationOfSuccessionAPI.Models;
using maghriby.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimitationOfSuccessionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeirsController : ControllerBase
    {
        List<Heirs> heir = new List<Heirs>();
        // GET: api/Heirs
        [HttpGet]
        public List<Heirs> Get()
        {
            return heir;
        }

        // GET: api/Heirs/5
        [HttpGet("{GetAsync}/{NationalNumber}")]
        public async Task<dynamic> GetAsync(string NationalNumber)
        {
            DAL d = new DAL();
            string query = "select * from heirs where National_Number = '{0}'";
            DataTable dt = await d.selectdataasync(string.Format(query, NationalNumber));
            AllData data = new AllData();
            if (dt.Rows.Count > 0)
            {
                data.money = Convert.ToDouble(dt.Rows[0]["Money"]);
                data.national_number = dt.Rows[0]["National_Number"].ToString();
                data.is_there_husband = Convert.ToDouble(dt.Rows[0]["husband"]);
                data.husband_part0 = Convert.ToDouble(dt.Rows[0]["husband_part"]);
                data.is_there_wife = Convert.ToDouble(dt.Rows[0]["wife"]);
                data.wife_part0 = Convert.ToDouble(dt.Rows[0]["wife_part"]);
                data.is_there_sons = Convert.ToDouble(dt.Rows[0]["boys"]);
                data.sons_part0 = Convert.ToDouble(dt.Rows[0]["boys_part"]);
                data.is_there_girls = Convert.ToDouble(dt.Rows[0]["girls"]);
                data.girls_part0 = Convert.ToDouble(dt.Rows[0]["girls_part"]);
                data.is_there_father = Convert.ToDouble(dt.Rows[0]["father"]);
                data.father_part0 = Convert.ToDouble(dt.Rows[0]["father_part"]);
                data.is_there_mother = Convert.ToDouble(dt.Rows[0]["mother"]);
                data.mother_part0 = Convert.ToDouble(dt.Rows[0]["mother_part"]);
                data.is_there_brothers = Convert.ToDouble(dt.Rows[0]["brothers"]);
                data.brothers_part0 = Convert.ToDouble(dt.Rows[0]["brothers_part"]);
                data.is_there_sisters = Convert.ToDouble(dt.Rows[0]["sisters"]);
                data.sisters_part0 = Convert.ToDouble(dt.Rows[0]["sisters_part"]);
                data.is_there_m_stepbrothers = Convert.ToDouble(dt.Rows[0]["m_stepbrothers"]);
                data.m_stepbrothers_part0 = Convert.ToDouble(dt.Rows[0]["m_stepbrothers_part"]);
                data.is_there_f_stepbrothers = Convert.ToDouble(dt.Rows[0]["f_stepbrothers"]);
                data.f_stepbrothers_part0 = Convert.ToDouble(dt.Rows[0]["f_stepbrothers_part"]);
                data.is_there_f_stepsisters = Convert.ToDouble(dt.Rows[0]["f_stepsisters"]);
                data.f_stepsisters_part0 = Convert.ToDouble(dt.Rows[0]["f_stepsisters_part"]);
                data.is_there_bro_sons = Convert.ToDouble(dt.Rows[0]["bro_sons"]);
                data.bro_sons_part0 = Convert.ToDouble(dt.Rows[0]["bro_sons_part"]);
                data.is_there_uncles = Convert.ToDouble(dt.Rows[0]["uncles"]);
                data.uncles_part0 = Convert.ToDouble(dt.Rows[0]["uncles_part"]);
                data.wives_nums = Convert.ToDouble(dt.Rows[0]["wives_nums"]);
                data.sons_nums = Convert.ToDouble(dt.Rows[0]["boys_nums"]);
                data.girls_nums = Convert.ToDouble(dt.Rows[0]["girls_nums"]);
                data.brothers_nums = Convert.ToDouble(dt.Rows[0]["brothers_nums"]);
                data.sisters_nums = Convert.ToDouble(dt.Rows[0]["sisters_nums"]);
                data.m_stepbrothers_nums = Convert.ToDouble(dt.Rows[0]["m_stepbrothers_nums"]);
                data.f_stepbrothers_nums = Convert.ToDouble(dt.Rows[0]["f_stepbrothers_nums"]);
                data.f_stepsisters_nums = Convert.ToDouble(dt.Rows[0]["f_stepsisters_nums"]);
                data.bro_sons_nums = Convert.ToDouble(dt.Rows[0]["bro_sons_nums"]);
                data.uncles_nums = Convert.ToDouble(dt.Rows[0]["uncles_nums"]);
                return data;
            }
            else
            {
                data.money = 0;
                data.national_number = "0";
                data.is_there_husband = 0;
                data.husband_part0 = 0;
                data.is_there_wife = 0;
                data.wife_part0 = 0;
                data.is_there_sons = 0;
                data.sons_part0 = 0;
                data.is_there_girls = 0;
                data.girls_part0 = 0;
                data.is_there_father = 0;
                data.father_part0 = 0;
                data.is_there_mother = 0;
                data.mother_part0 = 0;
                data.is_there_brothers = 0;
                data.brothers_part0 = 0;
                data.is_there_sisters = 0;
                data.sisters_part0 = 0;
                data.is_there_m_stepbrothers = 0;
                data.m_stepbrothers_part0 = 0;
                data.is_there_f_stepbrothers = 0;
                data.f_stepbrothers_part0 = 0;
                data.is_there_f_stepsisters = 0;
                data.f_stepsisters_part0 = 0;
                data.is_there_bro_sons = 0;
                data.bro_sons_part0 = 0;
                data.is_there_uncles = 0;
                data.uncles_part0 = 0;
                data.wives_nums = 0;
                data.sons_nums = 0;
                data.girls_nums = 0;
                data.brothers_nums = 0;
                data.sisters_nums = 0;
                data.m_stepbrothers_nums = 0;
                data.f_stepbrothers_nums = 0;
                data.f_stepsisters_nums = 0;
                data.bro_sons_nums = 0;
                data.uncles_nums = 0;
                return data;
            }
            return null;
        }

        // POST: api/Heirs
        [HttpPost]
        public async Task<dynamic> PostAsync(AllData data)
        {
            DAL d = new DAL();
            string query = "select * from heirs where National_Number = '{0}'";
            DataTable dt = await d.selectdataasync(string.Format(query, data.national_number));
            string uploaded = "Data has been uploaded";
            string isexist = "This National Number is exist";
            if (dt.Rows.Count > 0)
            {
                return isexist;
            }
            else
            {
                string querys = "INSERT INTO heirs (National_Number, Money,husband ,husband_part,wife,wife_part,wives_nums,boys,boys_part,boys_nums,girls,girls_part,girls_nums,father,father_part,mother,mother_part,brothers,brothers_part,brothers_nums,sisters,sisters_part,sisters_nums,m_stepbrothers,m_stepbrothers_part,m_stepbrothers_nums,f_stepbrothers,f_stepbrothers_part,f_stepbrothers_nums,f_stepsisters,f_stepsisters_part,f_stepsisters_nums,bro_sons,bro_sons_part,bro_sons_nums,uncles,uncles_part,uncles_nums ) " +
                "VALUES('{0}', '{1}','{2}' ,'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}' ) ";
                await d.insertdataasync(string.Format(querys, data.national_number, data.money, data.is_there_husband, data.husband_part0, data.is_there_wife, data.wife_part0, data.wives_nums, data.is_there_sons, data.sons_part0, data.sons_nums, data.is_there_girls, data.girls_part0, data.girls_nums, data.is_there_father, data.father_part0, data.is_there_mother, data.mother_part0, data.is_there_brothers, data.brothers_part0, data.brothers_nums, data.is_there_sisters, data.sisters_part0, data.sisters_nums, data.is_there_m_stepbrothers, data.m_stepbrothers_part0, data.m_stepbrothers_nums, data.is_there_f_stepbrothers, data.f_stepbrothers_part0, data.f_stepbrothers_nums, data.f_stepbrothers_nums, data.is_there_f_stepsisters, data.f_stepsisters_part0, data.f_stepsisters_nums, data.is_there_bro_sons, data.bro_sons_part0, data.bro_sons_nums, data.is_there_uncles, data.uncles_part0, data.uncles_nums));
                return uploaded;
            }
            return null;
        }

        // PUT: api/Heirs/5
        //[HttpPut("{id}")]
        /*public List<Friend> Put(int id, [FromBody] Friend friend)
        {
            Friend friendToUpdate = friends.Find(f => f.id == id);
            int index = friends.IndexOf(friendToUpdate);

            friends[index].firstname = friend.firstname;
            friends[index].lastname = friend.lastname;
            friends[index].location = friend.location;
            friends[index].dateOfHire = friend.dateOfHire;

            return friends;
        }*/

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        /*public List<Friend> Delete(int id)
        {
            Friend friend = friends.Find(f => f.id == id);
            friends.Remove(friend);
            return friends;
        }*/

    }
}
