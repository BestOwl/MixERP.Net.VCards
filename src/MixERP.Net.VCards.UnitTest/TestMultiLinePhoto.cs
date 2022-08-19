using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;

namespace MixERP.Net.VCards.UnitTest
{
    public class TestMultiLinePhoto
    {
        [Fact]
        public void TestDeserializeMultiLinePhoto()
        {
            string vcf = File.ReadAllText("multi-line-photo.vcf");
            List<VCard> vCards = Deserializer.GetVCards(vcf).ToList();
            VCard card = vCards.First();
            Assert.NotNull(card.Photo);
            Assert.True(card.Photo.IsEmbedded);
            byte[] imageBuffer = Convert.FromBase64String(card.Photo.Contents);
            IImageFormat format = Image.DetectFormat(imageBuffer);
            Assert.Equal("JPEG", format.Name);
            Image.Load(imageBuffer);
        }
    }
}