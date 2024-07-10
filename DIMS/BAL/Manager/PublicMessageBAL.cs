using DIMS.BAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DIMS.BAL.Manager
{
    public static class PublicMessageBAL
    {
        public static List<PublicMessage> GetPublicMessage()
        {
            using (var context = new DIMSContainer())
            {
                var institutes = (from i in context.PublicMessage.AsNoTracking()
                                  orderby i.PublicMessageID ascending
                                  select i
                                  ).ToList();

                return institutes;
            }
        }

        public static List<PublicMessage> GetPublicMessageByInstituteID(int rehabInstituteID)
        {
            using (var context = new DIMSContainer())
            {
                var institutes = (from i in context.PublicMessage.AsNoTracking()
                                 where i.RehabilitationInstituteID == rehabInstituteID
                                 select i
                                  ).ToList();

                return institutes;
            }
        }

        public static PublicMessage GetPublicMessageByID(int PublicMessageID)
        {
            using (var context = new DIMSContainer())
            {
                var institute = (from i in context.PublicMessage.AsNoTracking()
                                 where i.PublicMessageID == PublicMessageID
                                 select i
                                  ).FirstOrDefault();

                return institute;
            }
        }

        public static void AddPublicMessage(PublicMessage PublicMessage)
        {
            using (var context = new DIMSContainer())
            {
                context.PublicMessage.Add(PublicMessage);
                context.SaveChanges();
            }
        }


        public static void UpdatePublicMessage(PublicMessage publicMessage)
        {
            using (var context = new DIMSContainer())
            {
                var institute = (from i in context.PublicMessage
                                 where i.PublicMessageID == publicMessage.PublicMessageID
                                 select i).FirstOrDefault();
                if (institute != null)
                {
                    institute.Message = publicMessage.Message;
                    institute.DatePosted = publicMessage.DatePosted;
                }
                context.SaveChanges();
            }
        }
        //delete the existing message 
        public static void DeletePublicMessage(int publicMessageID)
        {
            using (var context = new DIMSContainer())
            {
                var message = (from i in context.PublicMessage
                               where i.PublicMessageID == publicMessageID
                               select i).FirstOrDefault();

                if (message != null)
                {
                    context.PublicMessage.Remove(message);
                    context.SaveChanges();
                }
            }
        }



    }
}