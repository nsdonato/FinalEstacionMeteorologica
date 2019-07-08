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
import ToastMessage from "./components/ToastMessage/ToastMessage";

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
      .post("http://localhost:57400/api/weatherstation/" + type)
      .then(result => {
        setDataWeather({ ...result.data, isNull: false });
        handleShow("Suscribe correctly");
      })
      .catch(error => {
        setDataWeather({ isNull: true });
        handleShow("Error Suscribe");
      });
  };

  var handleUnsuscribe = async type => {
    await axios
      .delete("http://localhost:57400/api/weatherstation/" + type)
      .then(result => {
        setDataWeather({ ...result.data, isNull: false });
        handleShow("Unsuscribe correctly");
      })
      .catch(error => {
        setDataWeather({ isNull: true });
        handleShow("Error Unsuscribe");
      });
  };

  const cardStyle = {
    width: '33%'
  }
  return (
    <div className="App">
      <header className="">
        <Container>
          {dataWeather.isNull === false ? (
            <Row>
              <WeatherActualCondition
                style={cardStyle} data={dataWeather.weatherActualCondition}
                cickSuscribe={() => handleSuscribe("WeatherActualCondition")}
                cickUnsuscribe={() =>
                  handleUnsuscribe("WeatherActualCondition")
                }
              />
              <WeatherSimpleForecast style={cardStyle}  data={dataWeather.weatherSimpleForecast} />
              <WeatherStatistics style={cardStyle}  data={dataWeather.weatherStatistics} />
              
            </Row>
          ) : (
            <Row>
              <Col>
                <Card style={{ width: "100%" }}>
                  <Card.Body>
                    <Card.Title>Ups...</Card.Title>
                    <Card.Text>
                      An error occurred when consulting the weather data.
                    </Card.Text>
                  </Card.Body>
                </Card>
              </Col>
            </Row>
          )}
          <ToastMessage 
                close={handleClose}
                show={showToast.show}
                info={showToast.info}
              />
        </Container>
      </header>
    </div>
  );
}

export default App;
