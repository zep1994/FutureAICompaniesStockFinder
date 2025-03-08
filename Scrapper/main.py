from fastapi import FastAPI, HTTPException
from celery import Celery
import logging

app = FastAPI()

# Configure logging
logging.basicConfig(level=logging.INFO, format="%(asctime)s - %(levelname)s - %(message)s")
logger = logging.getLogger(__name__)

# Celery Configuration (Using Redis)
celery = Celery("tasks", broker="redis://localhost:6379/0", backend="redis://localhost:6379/0")

# Test Endpoint
@app.get("/")
def read_root():
    return {"message": "Python Scraper API is running"}

@app.post("/scrape")
async def scrape_website(url: str):
    if not url.startswith("http"):
        logger.error(f"Invalid URL: {url}")
        raise HTTPException(status_code=400, detail="Invalid URL")

    logger.info(f"Received scraping request for: {url}")
    
    # Send task to Celery
    task = scrape_task.delay(url)
    
    return {"task_id": task.id, "status": "Processing"}
