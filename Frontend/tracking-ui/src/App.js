// In je App.js of een ander hoofdcomponent
import React from 'react';
import TestPage from './TestPage';

function App() {
  return (
    <div>
      <h1>App</h1>
      <TestPage />
      {/* Voeg andere componenten toe zoals nodig */}
    </div>
  );
}

export default App;
