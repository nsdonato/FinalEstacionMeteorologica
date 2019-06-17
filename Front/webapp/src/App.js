import React, { useState, useEffect } from "react";
// import Card from "react-bootstrap/Card";
// import CardGroup from "react-bootstrap/CardGroup";
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
    condicionesActuales: {
      temp: 0,
      hum: 0,
      pres: 0
    }
  });

  useEffect(() => {
    setInterval(() => fetchData(), 10000);

    const fetchData = async () => {
      await axios("http://localhost:57400/api/estadometeorologico")
        .then(result => {
          setDataWeather({
            condicionesActuales: {
              temp: result.data.condicionesActuales.temp,
              hum: result.data.condicionesActuales.hum,
              pres: result.data.condicionesActuales.pres
            }
          });
        })
        .catch(error => {
          console.log(error);
        });
    };

    fetchData();
  }, []);

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
          <Row>
            <Col>
              <Card style={{ width: "18rem" }}>
                <Card.Img
                  variant="top"
                  src="http://www.placehold.it/100/100/"
                />
                <Card.Body>
                  <Card.Title>Tiempo actual</Card.Title>
                  <Card.Text>
                    Some quick example text to build on the card title and make
                    up the bulk of the card's content.
                  </Card.Text>
                </Card.Body>
              </Card>
            </Col>
            <Col>
              <Card style={{ width: "18rem" }}>
                <Card.Img
                  variant="top"
                  src="http://www.placehold.it/100/100/"
                />
                <Card.Body>
                  <Row>
                  <Col sm={12}> <Card.Title>Pronostico del tiempo</Card.Title> </Col>
                  </Row>
                  <Row>
                    <Col sm={8}>
                      <Card.Subtitle style={style}>
                        Temperatura: {dataWeather.condicionesActuales.temp}
                      </Card.Subtitle>
                    </Col>
                    <Col sm={2}>
                      <FontAwesomeIcon style={styleSun} icon={faSun} />
                    </Col>
                  </Row>
                  <Row>
                    <Col sm={8}>
                      <Card.Subtitle style={style}>
                        Humedad: {dataWeather.condicionesActuales.hum}
                      </Card.Subtitle>
                    </Col>
                    <Col sm={2}>
                      <FontAwesomeIcon style={styleSun} icon={faSun} />
                    </Col>
                  </Row>
                  <Row>
                    <Col sm={8}>
                      <Card.Subtitle style={style}>
                        Presión: {dataWeather.condicionesActuales.pres}
                      </Card.Subtitle>
                    </Col>
                    <Col sm={2}>
                      <FontAwesomeIcon style={styleSun} icon={faSun} />
                    </Col>
                  </Row>
                </Card.Body>
              </Card>
            </Col>
            <Col>
              <Card style={{ width: "18rem" }}>
                <Card.Img
                  variant="top"
                  src="http://www.placehold.it/100/100/"
                />
                <Card.Body>
                  <Card.Title>Estadisticas</Card.Title>
                  <Card.Text>
                    Some quick example text to build on the card title and make
                    up the bulk of the card's content.
                  </Card.Text>
                  <Button variant="primary">Mostrar</Button>
                </Card.Body>
              </Card>
            </Col>
          </Row>
        </Container>
      </header>
    </div>
  );
}

export default App;
