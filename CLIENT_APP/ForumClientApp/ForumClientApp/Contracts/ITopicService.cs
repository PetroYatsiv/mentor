using ForumClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Contracts
{
    public interface ITopicService
    {
        List<TopicViewModel> GetTopics();
        TopicViewModel GetTopic(int id);
        List<SectionViewModel> CeateNewTopic(TopicViewModel topic);
        List<SectionViewModel> DeleteTopic(int id);
        List<SectionViewModel> UpdateTopic(int id, TopicViewModel topic);
    }
}
