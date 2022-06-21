using System.Collections.Generic;

namespace Test2.Dto
{
    public class ProductsDto
    {
        public int IdOrder { get; set; }
        public List<ProductWithCommentDto> Products { get; set; }
    }
}