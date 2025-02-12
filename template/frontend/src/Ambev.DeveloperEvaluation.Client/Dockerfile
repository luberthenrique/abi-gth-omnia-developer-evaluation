FROM node:18-alpine AS build

WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .

RUN npm run build

FROM nginx:1.23-alpine

COPY --from=build /app/dist/ambev.developer-evaluation.client/browser /usr/share/nginx/html
#COPY default.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
