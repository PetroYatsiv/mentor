using ForumClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp.Contracts
{
    public interface ISectionService
    {
        List<SectionViewModel> GetSections();
        List<SectionViewModel> CreateNewSection(SectionViewModel sectionViewModel);
        List<SectionViewModel> DeleteSection(int id);
        List<SectionViewModel> UpdateSection(int id, SectionViewModel section);
    }
}
