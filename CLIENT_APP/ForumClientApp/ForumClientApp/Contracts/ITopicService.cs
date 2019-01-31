using ForumClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Contracts
{
    interface ITopicService
    {
        List<TopicViewModel> GetTopics();
        TopicViewModel GetTopic(int id);
    }
}
