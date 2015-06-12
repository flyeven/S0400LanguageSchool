using System;

namespace LanguageSchool.Interfaces.Person.Types.Client
{
    public interface ICourseParticipant : IClient
    {
        string ClientType { get; set; }
    }
}
