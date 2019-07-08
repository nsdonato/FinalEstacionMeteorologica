import axios from "axios";
import React, { useState, useEffect } from "react";
import Card from "react-bootstrap/Card";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import CONFIG from "./config/config";
import WeatherCurrentCondition from "./components/WeatherCurrentCondition/WeatherCurrentCondition";
import WeatherSimpleForecast from "./components/WeatherSimpleForecast/WeatherSimpleForecast";
import WeatherStatistics from "./components/WeatherStatistics/WeatherStatistics";

import "./App.css";

function App() {
  const [dataWeather, setDataWeather] = useState([]);
  const [showToast, setShowToast] = useState({ show: false, info: "" });

  const handleShow = msg => setShowToast({ show: true, info: msg });
  const handleClose = () => setShowToast({ show: false, info: "" });

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
      .post(CONFIG.API + type)
      .then(result => {
        setDataWeather({ ...result.data, isNull: false });
        handleShow(CONFIG.SUSCRIBE_OK);
      })
      .catch(error => {
        setDataWeather({ isNull: true });
        handleShow(CONFIG.SUSCRIBE_ERROR);
      });
  };

  var handleUnsuscribe = async type => {
    await axios
      .delete(CONFIG.API + type)
      .then(result => {
        setDataWeather({ ...result.data, isNull: false });
        handleShow(CONFIG.UNSUSCRIBE_OK);
      })
      .catch(error => {
        setDataWeather({ isNull: true });
        handleShow(CONFIG.UNSUSCRIBE_ERROR);
      });
  };

  const cardStyle = {
    width: "33%"
  };
  return (
    <div className="App">
      <header className="">
        <Container>
          {dataWeather.isNull === false ? (
            <Row>
              <WeatherCurrentCondition
                close={handleClose}
                show={showToast.show}
                info={showToast.info}
                style={cardStyle}
                data={dataWeather.weatherCurrentCondition}
                cickSuscribe={() =>
                  handleSuscribe(CONFIG.WEATHER_CURRENT_CONDITION)
                }
                cickUnsuscribe={() =>
                  handleUnsuscribe(CONFIG.WEATHER_CURRENT_CONDITION)
                }
              />
              <WeatherSimpleForecast
                style={cardStyle}
                data={dataWeather.weatherSimpleForecast}
              />
              <WeatherStatistics
                style={cardStyle}
                data={dataWeather.weatherStatistics}
              />
            </Row>
          ) : (
            <Card style={{ width: "100%" }}>
              <Card.Body>
                <Card.Title>Ups...</Card.Title>
                <Card.Text>{CONFIG.FETCH_ERROR}</Card.Text>
              </Card.Body>
            </Card>
          )}
        </Container>
      </header>
    </div>
  );
}

export default App;
