FROM node:18-alpine
WORKDIR /app

# Install dependencies
COPY package*.json ./
RUN npm install

# Copy application code
COPY . .

# Expose Vite's default dev port (typically 5173)
EXPOSE 5173

# Run the Vite development server
CMD ["npm", "run", "dev"]
