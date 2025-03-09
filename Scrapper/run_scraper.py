import sys
import os

# Ensure the Scrapper directory is included in Python's module search path
sys.path.append(os.path.dirname(os.path.abspath(__file__)))


from scrapyscript import Job, Processor
import logging

# Configure logging
logging.basicConfig(level=logging.INFO, format="%(asctime)s - %(levelname)s - %(message)s")

def run_scrapy_script():
    processor = Processor()
    job = Job(AIProductSpider)

    results = processor.run(job)

    print("\n🎯 Scraping Complete! Here are the results:\n")
    for result in results:
        print(f"✅ {result}\n")
        logging.info(f"Scraped Data: {result}")

if __name__ == "__main__":
    run_scrapy_script()
