import axios from "axios";
import React, { useState, useEffect } from "react";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import CONFIG from "./config/config";
import WeatherActualCondition from "./components/WeatherActualCondition/WeatherActualCondition";
import WeatherSimpleForecast from "./components/WeatherSimpleForecast/WeatherSimpleForecast";
import WeatherStatistics from "./components/WeatherStatistics/WeatherStatistics";

import "./App.css";

function App() {
 
  const [dataWeather, setDataWeather] = useState([]);

  const fetchData = async () => {
    await axios
      .get(CONFIG.API)
      .then(result => {
        setDataWeather({ ...result.data, isNull: false });
      })
      .catch(error => {
        setDataWeather({ isNull: true });
      });
  };

  useEffect(() => {
    setInterval(() => fetchData(), 20000);
    fetchData();
  }, []);

  var handleSuscribe = async type => {
    await axios
      .post("http://localhost:57400/api/weatherstation/" + type)
      .then(result => {
        setDataWeather({ ...result.data, isNull: false });
      })
      .catch(error => {
        setDataWeather({ isNull: true });
      });
  };

  var handleUnsuscribe = async type => {
    await axios
      .delete("http://localhost:57400/api/weatherstation/" + type)
      .then(result => {
        debugger;
        setDataWeather({ ...result.data, isNull: false });
      })
      .catch(error => {
        setDataWeather({ isNull: true });
      });
  };

  return (
    <div className="App">
      <header className="">
        <Container>
          {dataWeather.isNull === false ? (
            <Row>
              {dataWeather.weatherActualCondition != null ? (
                <div>
                  <WeatherActualCondition
                    data={dataWeather.weatherActualCondition}
                  cickSuscribe={() => handleSuscribe("WeatherActualCondition")}
                  cickUnsuscribe={() => handleUnsuscribe("WeatherActualCondition")}
                  />
                </div>
              ) : null}
              {dataWeather.weatherSimpleForecast != null ? (
                <WeatherSimpleForecast
                  data={dataWeather.weatherSimpleForecast}
                />
              ) : null}
              {dataWeather.weatherStatistics != null ? (
                <WeatherStatistics data={dataWeather.weatherStatistics} />
              ) : null}
            </Row>
          ) : (
            <Row>
              <Col>
                <Card style={{ width: "18rem" }}>
                  <Card.Body>
                    <Card.Title>Error</Card.Title>
                    <Card.Text>
                      An error occurred when consulting the weather data.
                    </Card.Text>
                  </Card.Body>
                </Card>
              </Col>
            </Row>
          )}
        </Container>
      </header>
    </div>
  );
}

export default App;
