import React from "react";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSun } from "@fortawesome/free-solid-svg-icons";
import ButtonSuscribe from "../Buttons/ButtonSuscribe/ButtonSuscribe";
import ButtonUnsuscribe from "../Buttons/ButtonUnsuscribe/ButtonUnsuscribe";

const WeatherActualCondition = props => {
  const style = {
    textAlign: "left"
  };

  const styleSun = {
    color: "yellow"
  };

  return (
    <div>
      {props.data.isSuscribed === true ? (
        <Col>
          <Card style={{ width: "18rem" }}>
            <Card.Img variant="top" src="http://www.placehold.it/100/100/" />
            <Card.Body>
              <Row>
                <Col sm={12}>
                  {" "}
                  <Card.Title>Actual Conditions</Card.Title>{" "}
                </Col>
              </Row>
              <Row>
                <Col sm={8}>
                  <Card.Subtitle style={style}>
                    Temperature: {props.data.weatherData.temp}°
                  </Card.Subtitle>
                </Col>
                <Col sm={2}>
                  <FontAwesomeIcon style={styleSun} icon={faSun} />
                </Col>
              </Row>
              <Row>
                <Col sm={8}>
                  <Card.Subtitle style={style}>
                    Humidity: {props.data.weatherData.hum}%
                  </Card.Subtitle>
                </Col>
                <Col sm={2}>
                  <FontAwesomeIcon style={styleSun} icon={faSun} />
                </Col>
              </Row>
              <Row>
                <Col sm={8}>
                  <Card.Subtitle style={style}>
                    Pressure: {props.data.weatherData.pres}
                  </Card.Subtitle>
                </Col>
                <Col sm={2}>
                  <FontAwesomeIcon style={styleSun} icon={faSun} />
                </Col>
              </Row>
            </Card.Body>
            <ButtonSuscribe
              text="Suscribe"
              onClick={props.cickSuscribe}
            />
            <ButtonUnsuscribe
              text="Unsuscribe"
              onClick={props.cickUnsuscribe}
            />
          </Card>
        </Col>
      ) : (
        <Col>
          <Card style={{ width: "18rem" }}>
            <Card.Img variant="top" src="http://www.placehold.it/100/100/" />
            <Card.Body>
              <Card.Title>Actual Conditions</Card.Title>
              <Card.Text style={style}>
                {"You need to subscribe 'Actual Conditions' to the Weather Station Channel."}
              </Card.Text>
            </Card.Body>
            <ButtonSuscribe
              text="Suscribe"
              onClick={props.cickSuscribe}
            />
            <ButtonUnsuscribe
              text="Unsuscribe"
              onClick={props.cickUnsuscribe}
            />
          </Card>
        </Col>
      )}
    </div>
  );
};

export default WeatherActualCondition;
