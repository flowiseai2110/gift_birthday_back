using HtmlAgilityPack;

namespace API.CORE.SUPABASE
{
    public class ProductoWebScrapt
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagen_url { get; set; }
        public string marca { get; set; }
        public string precio { get; set; }


    }
    public class ScrapearWebAlibaba
    {

        public async Task<List<ProductoWebScrapt>> ScrapeProductosAsync()
        {
            var productos = new List<ProductoWebScrapt>();
            var url = "https://www.tailoy.com.pe/mundo-bebe/aseo-del-bebe/aseo-personal-para-bebes.html?p=2"; // Reemplaza con la URL real
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodos = doc.DocumentNode.SelectNodes("//li[contains(@class, 'product-item')]");

            if (nodos != null)
            {
                foreach (var nodo in nodos)
                {
                    var nombre = nodo.SelectSingleNode(".//div[contains(@class, 'label')]")?.InnerText.Trim();
                    //var marca = nodo.SelectSingleNode(".//div[contains(@class, 'brand-label')]")?.InnerText.Trim();
                    var descripcion = nodo.SelectSingleNode(".//a[contains(@class, 'product-item-link')]")?.InnerText.Trim();
                    var imagen = nodo.SelectSingleNode(".//img")?.GetAttributeValue("src", "");
                    var price = nodo.SelectSingleNode(".//span[@class='price']")?.InnerText;

                    productos.Add(new ProductoWebScrapt
                    {
                        nombre = nombre,
                        descripcion = descripcion,
                        //marca = marca,
                        imagen_url = imagen,
                        precio = price
                    });
                }
            }

            return productos;
        }
    }
    public class ScrapearWeb {

        public async Task<List<ProductoWebScrapt>> ScrapeProductosAsync()
        {
            var productos = new List<ProductoWebScrapt>();
            var url = "https://www.tailoy.com.pe/mundo-bebe/aseo-del-bebe/aseo-personal-para-bebes.html?p=2"; // Reemplaza con la URL real
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodos = doc.DocumentNode.SelectNodes("//li[contains(@class, 'product-item')]");

            if (nodos != null)
            {
                foreach (var nodo in nodos)
                {
                    var nombre = nodo.SelectSingleNode(".//div[contains(@class, 'label')]")?.InnerText.Trim();
                    //var marca = nodo.SelectSingleNode(".//div[contains(@class, 'brand-label')]")?.InnerText.Trim();
                    var descripcion = nodo.SelectSingleNode(".//a[contains(@class, 'product-item-link')]")?.InnerText.Trim();
                    var imagen = nodo.SelectSingleNode(".//img")?.GetAttributeValue("src", ""); 
                    var price = nodo.SelectSingleNode(".//span[@class='price']")?.InnerText;

                    productos.Add(new ProductoWebScrapt
                    {
                        nombre = nombre,
                        descripcion = descripcion,
                        //marca = marca,
                        imagen_url = imagen,
                        precio = price
                    });
                }
            }

            return productos;
        }
    }
}
