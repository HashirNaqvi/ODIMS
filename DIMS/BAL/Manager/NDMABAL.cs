using DIMS.BAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DIMS.BAL.Manager
{
    public static class NDMABAL
    {
        
        public static NDMAUser AuthenticateNDMA(NDMAUser ndma)
        {
            using (var context = new DIMSContainer())
            {
                return (from i in context.NDMAUser
                                 where i.Email == ndma.Email && i.Password == ndma.Password
                                 select i).FirstOrDefault();
                

            }
        }

        public static void AddNDMA(NDMAUser ndma)
        {
            using (var context = new DIMSContainer())
            {
                context.NDMAUser.Add(ndma);
                context.SaveChanges();
            }
        }

        public static void UpdateNDMA(NDMAUser ndma)
        {
            using (var context = new DIMSContainer())
            {
                var NDMA = (from i in context.NDMAUser
                            where i.NDMAUserID == ndma.NDMAUserID
                                 select i).FirstOrDefault();
                if (NDMA != null)
                {
                    NDMA.FirstName = ndma.FirstName;
                    NDMA.LastName = ndma.LastName;
                    NDMA.Address1 = ndma.Address1;
                    NDMA.City = ndma.City;
                    NDMA.State = ndma.State;
                    NDMA.FirstName = ndma.FirstName;
                    NDMA.Email = ndma.Email;
                    NDMA.Password = ndma.Password;
                }
                context.SaveChanges();
            }
        }

    }
}