namespace Football.Validations
{
    using System.ComponentModel.DataAnnotations;

    public class ImageValidations : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var imageUrl = value as string;
            if (imageUrl == null)
            {
                return true;
            }

            return imageUrl.EndsWith(".jpeg")
                || imageUrl.EndsWith(".jpg")
                || imageUrl.EndsWith(".png")
                || imageUrl.EndsWith(".gif");
        }
    }
}