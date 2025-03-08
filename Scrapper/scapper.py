import scrapy

class AIProductSpider(scrapy.Spider):
    name = "ai_product_spider"
    start_urls = ["https://example.com"]  # Change to actual URL

    def parse(self, response):
        """Extract AI tool name, description, and tags from the webpage."""

        items = []
        
        for tool in response.css("div.flex.flex-wrap.gap-4.rounded-lg.bg-white.p-4.shadow-xl"):
            item = {
                "name": tool.css("h2.text-2xl.font-bold.text-slate-800::text").get(),
                "description": tool.css("div.mt-auto.pt-4.font-bold a::text").get(),
                "tags": [tag.css("a::text").get().split("(")[0].strip() for tag in tool.css("div.capitalize")]
            }
            items.append(item)
            logging.info(f"Scraped: {item}")  # Log the extracted data
            print(f"✅ Scraped: {item}")  # Print the extracted data to console
            yield item
    __all__ = ["AIProductSpider"]