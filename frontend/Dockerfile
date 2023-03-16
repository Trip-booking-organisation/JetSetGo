FROM node:18 as build
WORKDIR /app
COPY . .
RUN npm install
COPY . /app
RUN npm run build

FROM nginx:stable
COPY --from=build /app/dist/frontend/ /usr/share/nginx/html
EXPOSE 80
