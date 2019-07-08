import React from "react";
import Card from "react-bootstrap/Card";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import ButtonSuscribe from "../Buttons/ButtonSuscribe/ButtonSuscribe";
import ButtonUnsuscribe from "../Buttons/ButtonUnsuscribe/ButtonUnsuscribe";
import ListGroup from "react-bootstrap/ListGroup";
import CONFIG from "../../config/config";
import Image from "react-bootstrap/Image";
import Temperature from "../../images/temperature.png";
import Humidity from "../../images/humidity.png";
import Pressure from "../../images/barometer.png";
import ToastMessage from "../../components/ToastMessage/ToastMessage";

const WeatherCurrentCondition = props => {
  const styleLeft = {
    textAlign: "left"
  };
  const imgStyle = {
    width: "50%"
  };
  return (
    <Card style={{ width: props.style.width }}>
      <Card.Header>Current Conditions</Card.Header>
      <Card.Body>
        {props.data.isSuscribed === true ? (
          <div>
            <ListGroup style={styleLeft} variant="flush">
              <ListGroup.Item key={1}>
                <Row>
                  <Col md={8}>
                    {" "}
                    Temperature: {props.data.weatherData.temp}°{" "}
                  </Col>
                  <Col md={4}>
                    <Image style={imgStyle} src={Temperature} />
                  </Col>
                </Row>
              </ListGroup.Item>
              <ListGroup.Item key={2}>
                <Row>
                  <Col md={8}> Humidity: {props.data.weatherData.hum}% </Col>
                  <Col md={4}>
                    <Image style={imgStyle} src={Humidity} />
                  </Col>
                </Row>
              </ListGroup.Item>
              <ListGroup.Item key={3}>
                <Row>
                  <Col md={8}>Pressure: {props.data.weatherData.pres} </Col>
                  <Col md={4}>
                    <Image style={imgStyle} src={Pressure} />
                  </Col>
                </Row>
              </ListGroup.Item>
            </ListGroup>
          </div>
        ) : (
          <Card.Text style={styleLeft}>{CONFIG.SUSCRIBE}</Card.Text>
        )}
      </Card.Body>
      <ToastMessage
        close={props.close}
        show={props.show}
        info={props.info}
      />
      <ButtonSuscribe text={CONFIG.BTN_SUSCRIBE} onClick={props.cickSuscribe} />
      <ButtonUnsuscribe
        text={CONFIG.BTN_UNSUSCRIBE}
        onClick={props.cickUnsuscribe}
      />
    </Card>
  );
};

export default WeatherCurrentCondition;
