using ForumClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Contracts
{
    public interface ISubtopicService
    {
        List<SubTopicViewModel> GetSubTopics(int topicId);
        List<SubTopicViewModel> CreateNewSubTopic(SubTopicViewModel sectionViewModel);
        List<SubTopicViewModel> DeleteSubTopic(int id);
        List<SubTopicViewModel> UpdateSubTopic(int id, SubTopicViewModel section);
    }
}
