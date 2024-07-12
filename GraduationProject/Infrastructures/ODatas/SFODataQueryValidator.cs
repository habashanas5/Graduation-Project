using Microsoft.AspNetCore.OData.Query.Validator;
using Microsoft.AspNetCore.OData.Query;

namespace GraduationProject.Infrastructures.ODatas
{
    public class SFODataQueryValidator : ODataQueryValidator
    {
        public override void Validate(ODataQueryOptions options, ODataValidationSettings validationSettings)
        {
            validationSettings.MaxNodeCount = 300;
            base.Validate(options, validationSettings);
        }
    }
}