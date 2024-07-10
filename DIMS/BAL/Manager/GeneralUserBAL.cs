using DIMS.BAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DIMS.BAL.Manager
{
    public static class GeneralUserBAL
    {
        public static List<GeneralUser> GetAllGeneralUsers()
        {
            using (var context = new DIMSContainer())
            {
                var GeneralUsers = (from i in context.GeneralUser.AsNoTracking()
                                  orderby i.UserName ascending
                                  select i
                                  ).ToList();

                return GeneralUsers;
            }
        }
        public static GeneralUser AuthenticateGeneralUser(GeneralUser generalUser)
        {
            using (var context = new DIMSContainer())
            {
                return (from i in context.GeneralUser
                        where i.Email == generalUser.Email && i.Password == generalUser.Password  && i.Active==true
                        select i).FirstOrDefault();


            }
        }

        public static void AddGeneralUser(GeneralUser generalUser)
        {
            using (var context = new DIMSContainer())
            {
                context.GeneralUser.Add(generalUser);
                context.SaveChanges();
            }
        }
        public static GeneralUser GetGeneralUserByID(int GeneralUserID)
        {
            using (var context = new DIMSContainer())
            {
                var GeneralUser = (from i in context.GeneralUser.AsNoTracking()
                                 where i.GeneralUserID == GeneralUserID
                                 select i
                                  ).FirstOrDefault();

                return GeneralUser;
            }
        }
        public static void UpdateGeneralUser(GeneralUser generalUser)
        {
            using (var context = new DIMSContainer())
            {
                var GeneralUser = (from i in context.GeneralUser
                                 where i.GeneralUserID == generalUser.GeneralUserID
                                 select i).FirstOrDefault();
                if (GeneralUser != null)
                {
                    GeneralUser.UserName = generalUser.UserName;
                    GeneralUser.Email = generalUser.Email;
                    GeneralUser.Password = generalUser.Password;
                    GeneralUser.Phone = generalUser.Phone;
                    GeneralUser.Active = generalUser.Active;
                }
                context.SaveChanges();
            }
        }
        public static void DeleteGeneralUser(int GeneralUserID)
        {
            using (var context = new DIMSContainer())
            {
                var info = (from i in context.GeneralUser
                            where i.GeneralUserID == GeneralUserID
                            select i);
                if (info != null)
                {
                    context.GeneralUser.RemoveRange(info);
                }
                context.SaveChanges();
            }
        }

    }
}