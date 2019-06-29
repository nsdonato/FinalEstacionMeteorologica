import React, { useState, useEffect } from "react";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Card from "react-bootstrap/Card";
import Button from "react-bootstrap/Button";
import axios from "axios";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSun } from "@fortawesome/free-solid-svg-icons";
import "./App.css";

function App() {
  const [dataWeather, setDataWeather] = useState({
    weatherActualCondition: {
      temp: null,
      hum: null,
      pres: null
    },
    weatherSimpleForecast: {
      temp: null,
      forecast: null
    },
    weatherStatistics: [{
      temp: null,
      hum: null,
      pres: null
    }],
    isNull: true
  });

  useEffect(() => {
    setInterval(() => fetchData(), 10000);
    const fetchData = async () => {
      await axios
        .get("http://localhost:57400/api/weatherstation")
        .then(result => {
          setDataWeather({
            weatherActualCondition: {
              temp: result.data.weatherActualCondition.weatherData.temp,
              hum: result.data.weatherActualCondition.weatherData.hum,
              pres: result.data.weatherActualCondition.weatherData.pres
            },
            weatherSimpleForecast: {
              temp: result.data.weatherSimpleForecast.temperature,
              forecast: result.data.weatherSimpleForecast.forecast
            },
            weatherStatistics: [{
              temp: result.data.weatherStatistics.weatherData.temp,
              hum: result.data.weatherStatistics.weatherData.hum,
              pres: result.data.weatherStatistics.weatherData.pres
            }],
            isNull: false
          })
          debugger;
          console.log({dataWeather});
        })
        .catch((error) => {
          debugger;
          console.log({dataWeather});
          console.log(error);
          setDataWeather({ isNull: true });
        });
    };

    fetchData();
  }, []);

  var handleSuscribe = async (weatherType) => {
    debugger;
    await axios
      .post("http://localhost:57400/api/weatherstation/{weatherType}")
      .then(result => {
        debugger;
        console.log(result);
        setDataWeather({
          weatherActualCondition: {
            temp: result.data.weatherActualCondition.weatherData.temp,
            hum: result.data.weatherActualCondition.weatherData.hum,
            pres: result.data.weatherActualCondition.weatherData.pres
          },
          weatherStatistics: [{
            temp: result.data.weatherStatistics.weatherData.temp,
            hum: result.data.weatherStatistics.weatherData.hum,
            pres: result.data.weatherStatistics.weatherData.pres
          }],
          weatherSimpleForecast: {
            temp: result.data.weatherSimpleForecast.temperature,
            forecast: result.data.weatherSimpleForecast.forecast
          }
        });
        
      })
      .catch(error => {
        debugger;
        console.log(dataWeather);
        console.log(error);
      });
  }

  var handleUnsuscribe = async () => {
    debugger;
    await axios
      .delete("http://localhost:57400/api/weatherstation/{weatherType}")
      .then(result => {
        setDataWeather({
          weatherActualCondition: {
            temp: result.data.weatherActualCondition.weatherData.temp,
            hum: result.data.weatherActualCondition.weatherData.hum,
            pres: result.data.weatherActualCondition.weatherData.pres
          },
          weatherStatistics: [{
            temp: result.data.weatherStatistics.weatherData.temp,
            hum: result.data.weatherStatistics.weatherData.hum,
            pres: result.data.weatherStatistics.weatherData.pres
          }],
          weatherSimpleForecast: {
            temp: result.data.weatherSimpleForecast.temperature,
            forecast: result.data.weatherSimpleForecast.forecast
          }
        });
      })
      .catch(error => {
        console.log(error);
      });
  }

  const style = {
    textAlign: "left"
  };

  const styleSun = {
    color: "yellow"
  };

  return (
    <div className="App">
      <header className="">
        <Container>

          {dataWeather.isNull === false ?
          <Row><Col>{dataWeather.isNulls === true ? "true" : dataWeather.weatherActualCondition.temp }</Col></Row>
            // <Row>
            //   <Col>
            //     <Card style={{ width: "18rem" }}>
            //       <Card.Img
            //         variant="top"
            //         src="http://www.placehold.it/100/100/"
            //       />
            //       <Card.Body>
            //         <Row>
            //           <Col sm={12}> <Card.Title>Tiempo Actual</Card.Title> </Col>
            //         </Row>
            //         <Row>
            //           <Col sm={8}>
            //             <Card.Subtitle style={style}>
            //               Temperatura: {dataWeather.weatherActualCondition.temp === 'undefined' ? "-" : dataWeather.WeatherActualCondition.temp}
            //             </Card.Subtitle>
            //           </Col>
            //           <Col sm={2}>
            //             <FontAwesomeIcon style={styleSun} icon={faSun} />
            //           </Col>
            //         </Row>
            //         <Row>
            //           <Col sm={8}>
            //             <Card.Subtitle style={style}>
            //               Humedad: {dataWeather.weatherActualCondition.hum === 'undefined' ? "-" : dataWeather.WeatherActualCondition.hum}
            //             </Card.Subtitle>
            //           </Col>
            //           <Col sm={2}>
            //             <FontAwesomeIcon style={styleSun} icon={faSun} />
            //           </Col>
            //         </Row>
            //         <Row>
            //           <Col sm={8}>
            //             <Card.Subtitle style={style}>
            //               Presión: {dataWeather.weatherActualCondition.pres === 'undefined' ? "-" : dataWeather.WeatherActualCondition.pres}
            //             </Card.Subtitle>
            //           </Col>
            //           <Col sm={2}>
            //             <FontAwesomeIcon style={styleSun} icon={faSun} />
            //           </Col>
            //         </Row>
            //       </Card.Body>
            //     </Card>
            //   </Col>
            //   <Col>
            //     <Card style={{ width: "18rem" }}>
            //       <Card.Img
            //         variant="top"
            //         src="http://www.placehold.it/100/100/"
            //       />
            //       <Card.Body>
            //         <Card.Title>Pronostico del Tiempo</Card.Title>
            //         <Card.Text>
            //           {dataWeather.weatherSimpleForecast.forecast === 'undefined' ? "Simple Forecast is not available" : dataWeather.weatherSimpleForecast.forecast}
            //         </Card.Text>
            //       </Card.Body>
            //     </Card>
            //   </Col>
            //   <Col>
            //     <Card style={{ width: "18rem" }}>
            //       <Card.Img
            //         variant="top"
            //         src="http://www.placehold.it/100/100/"
            //       />
            //       <Card.Body>
            //         <Card.Title>Estadisticas</Card.Title>
            //         <Card.Text>
            //           Some quick example text to build on the card title and make
            //           up the bulk of the card's content.
            //       </Card.Text>
            //         <Button variant="primary" onClick={handleSuscribe}>Suscribe</Button>
            //         <Button variant="primary" onClick={handleUnsuscribe}>Unsuscribe</Button>
            //       </Card.Body>
            //     </Card>
            //   </Col>
            // </Row>
            : <Row>
              <Col>
                <Card style={{ width: "18rem" }}>
                  <Card.Body>
                    <Card.Title>Error</Card.Title>
                    <Card.Text>
                      Ocurrió un error al consultar los datos del tiempo.
                  </Card.Text>
                  </Card.Body>
                </Card>
              </Col>
            </Row>}
        </Container>
      </header>
    </div>
  );
}

export default App;
