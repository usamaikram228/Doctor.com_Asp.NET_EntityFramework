using Project.Models;

namespace Project.RepositryPattern
{
    static  public class FeedBackRepository
    {
        static public List<FeedBack> getfeedBackbyid(int docId)
        {
            DbDoctorContext cx = new DbDoctorContext();
            List<FeedBack> list = new List<FeedBack>();
            list = cx.FeedBacks.ToList();
          
            List<FeedBack> itemsToRemove = new List<FeedBack>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].DoctorId != docId)
                {
                    itemsToRemove.Add(list[i]);
                }
            }

            foreach (var item in itemsToRemove)
            {
                list.Remove(item);
            }

            return list;
        }
        static public void  insertFeedback(FeedBack feedback)
        {
            DbDoctorContext cx = new DbDoctorContext();
            cx.FeedBacks.Add(feedback);
            cx.SaveChanges();
        }
    }
}
