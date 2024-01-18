import React from 'react';
import TrackingComponent from './TrackingComponent'; // Zorg ervoor dat het juiste pad naar TrackingComponent is opgenomen

const TestPage = () => {
  return (
    <div>
      <h1>Test Page</h1>
      <TrackingComponent page="TestPage" />
      {/* Voeg meer TrackingComponents toe zoals nodig voor andere elementen op de pagina */}
    </div>
  );
};

export default TestPage;