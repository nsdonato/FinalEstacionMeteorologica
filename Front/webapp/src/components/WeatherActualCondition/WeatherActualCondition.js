import React from "react";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSun } from "@fortawesome/free-solid-svg-icons";
import ButtonSuscribe from "../Buttons/ButtonSuscribe/ButtonSuscribe";
import ButtonUnsuscribe from "../Buttons/ButtonUnsuscribe/ButtonUnsuscribe";
import ListGroup from "react-bootstrap/ListGroup";

const WeatherActualCondition = props => {
  const styleLeft = {
    textAlign: "left"
  };

  const styleSun = {
    color: "yellow"
  };

  return (
    <Card style={{ width: props.style.width }}>
       <Card.Header>Actual Conditions</Card.Header>
      <Card.Body>
        {props.data.isSuscribed === true ? (
          <div>
            <ListGroup  style={styleLeft} variant="flush">
              <ListGroup.Item key={1}> Temperature: {props.data.weatherData.temp}°</ListGroup.Item>
              <ListGroup.Item key={2}> Humidity: {props.data.weatherData.hum}%</ListGroup.Item>
              <ListGroup.Item key={3}> Pressure: {props.data.weatherData.pres}</ListGroup.Item>
            </ListGroup>
            {/* <Row>
              <Col sm={8}>
                <Card.Subtitle style={styleLeft}>
                  Temperature: {props.data.weatherData.temp}°
                </Card.Subtitle>
              </Col>
              <Col sm={2}>
                <FontAwesomeIcon style={styleSun} icon={" "}/>
              </Col>
            </Row>
            <Row>
              <Col sm={8}>
                <Card.Subtitle style={styleLeft}>
                  Humidity: {props.data.weatherData.hum}%
                </Card.Subtitle>
              </Col>
              <Col sm={2}>
                <FontAwesomeIcon style={styleSun} icon={" "} />
              </Col>
            </Row>
            <Row> 
              <Col sm={8}>
                <Card.Subtitle style={styleLeft}>
                  Pressure: {props.data.weatherData.pres}
                </Card.Subtitle>
              </Col>
              <Col sm={2}>
                <FontAwesomeIcon style={styleSun} icon={" "}/>
              </Col>
            </Row>*/}
          </div>
        ) : (
          <Card.Text style={styleLeft}>
            {
              "You need to subscribe 'Actual Conditions' to the Weather Station Channel."
            }
          </Card.Text>
        )}
      </Card.Body>
      <ButtonSuscribe text="Suscribe" onClick={props.cickSuscribe} />
      <ButtonUnsuscribe text="Unsuscribe" onClick={props.cickUnsuscribe} />
    </Card>
  );
};

export default WeatherActualCondition;
