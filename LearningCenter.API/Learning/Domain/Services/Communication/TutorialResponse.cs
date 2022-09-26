using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class TutorialResponse : BaseResponse<Tutorial>
{
    public TutorialResponse(Tutorial resource) : base(resource)
    {
    }

    public TutorialResponse(string message) : base(message)
    {
    }
}