import React, { useState, useEffect } from "react";
// import Card from "react-bootstrap/Card";
// import CardGroup from "react-bootstrap/CardGroup";
import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Card from "react-bootstrap/Card";
import Button from "react-bootstrap/Button";
import axios from "axios";

import "./App.css";

function App() {
  const [dataWeather, setDataWeather] = useState({
    condicionesActuales: {
      temp: null,
      hum: null,
      pres: null
    }
  });

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios(
        "http://localhost:57400/api/estadometeorologico"
      );
      debugger;
      setDataWeather({
        condicionesActuales: {
          temp: result.data.condicionesActuales.temp,
          hum: result.data.condicionesActuales.hum,
          pres: result.data.condicionesActuales.pres
        }
      });
    };

    fetchData();
  }, []);

  const style = {
    textAlign: "left"
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
                  <Card.Title>Pronostico del tiempo</Card.Title>
                  <Row>
                    <Col>
                      <Card.Text style={style}>
                        Temperatura:{" "}
                        <Card.Subtitle>
                          {dataWeather.condicionesActuales.temp}
                        </Card.Subtitle>
                        Humedad:{" "}
                        <Card.Subtitle>
                          {dataWeather.condicionesActuales.hum}
                        </Card.Subtitle>
                        Presión:{" "}
                        <Card.Subtitle>
                          {dataWeather.condicionesActuales.pres}
                        </Card.Subtitle>
                      </Card.Text>
                    </Col>
                    <Col>
                      <Card.Text style={style}>
                        Sol {" "} 
                        <Card.Subtitle>{" "}</Card.Subtitle>
                        Nubes {" "} 
                        <Card.Subtitle>{" "}</Card.Subtitle>
                        Termometro {" "}
                        <Card.Subtitle>{" "}</Card.Subtitle></Card.Text>
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
