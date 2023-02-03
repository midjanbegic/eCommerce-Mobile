using Devision.eCommerce.Mobile.Interfaces;
using Devision.eCommerce.Mobile.Models;
using Newtonsoft.Json;

namespace Devision.eCommerce.Mobile.Services
{
    public class ProductService : IProductService
    {
        private string _baseUrl = "https://staging.komercijala.ba/api/products?importProviderKey=9dab1d09-eac7-4185-bec4-8032db2f0bc3";

        // get all products
        public async Task<List<Product>> GetList()
        {

            var returnResponse = new List<Product>();
            try
            {


                using (var client = new HttpClient())
                {
                    var apiResponse = await client.GetAsync(_baseUrl);
                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();

                        if (response != null)
                        {
                            returnResponse = JsonConvert.DeserializeObject<List<Product>>(response);


                        }
                    }


                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

            }

            return returnResponse;


        }

        //get single product
        public async Task<Product> GetProduct(string Sku)
        {
            // here should be created endpoint to get single product instead of fetching all products and then filtering them
            var allProducts = await GetList();
            var result = allProducts.Where(p => p.Sku == Sku).FirstOrDefault();
            return result;

        }


    }
    }
